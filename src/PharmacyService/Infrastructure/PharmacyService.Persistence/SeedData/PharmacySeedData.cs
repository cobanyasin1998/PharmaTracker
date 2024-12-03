using Bogus;
using Coban.Domain.Enums.Base;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Coban.Persistence.SeedData.Abstractions;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Persistence.SeedData;

public class PharmacySeedData : ISeedData
{
    private readonly IUnitOfWork _unitOfWork;

    public PharmacySeedData(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> SeedEntityData(int count = 5000)
    {
        bool isExistsRecords = await _unitOfWork.PharmacyReadRepository.GetAll().AnyAsync();
        if (!isExistsRecords)
        {
            HashSet<string> generatedLicenseNumbers = new HashSet<string>();
            HashSet<string> generatedNames = new HashSet<string>();

            Faker<PharmacyBranchAddressEntity> addressFaker = new Faker<PharmacyBranchAddressEntity>()
                .RuleFor(a => a.IsPrimary, f => f.Random.Bool())
                .RuleFor(a => a.Address, f => f.Address.FullAddress())
                .RuleFor(a => a.ProvinceId, f => f.Random.Long(1, 81))
                .RuleFor(a => a.DistrictId, f => f.Random.Long(1, 500))
                .RuleFor(a => a.NeighbourhoodId, f => f.Random.Long(1, 1000))
                .RuleFor(a => a.StreetId, f => f.Random.Long(1, 5000))
                .RuleFor(a => a.Latitude, f => (decimal)f.Address.Latitude())
                .RuleFor(a => a.Longitude, f => (decimal)f.Address.Longitude());

            Faker<PharmacyBranchContactEntity> contactFaker = new Faker<PharmacyBranchContactEntity>()
                .RuleFor(c => c.Type, f => f.PickRandom<EContactType>())
                .RuleFor(c => c.Value, f => f.Internet.Email());

            Faker<PharmacyBranchEntity> branchFaker = new Faker<PharmacyBranchEntity>()
                .RuleFor(b => b.Id, f => 0)
                .RuleFor(b => b.Name, f => f.Address.City() + "_Branch")
                .RuleFor(b => b.PharmacyBranchAddressEntities, f => addressFaker.Generate(f.Random.Int(1, 3)))
                .RuleFor(b => b.PharmacyBranchContactEntities, f => contactFaker.Generate(f.Random.Int(1, 5)));

            Faker<PharmacyEntity> pharmacyFaker = new Faker<PharmacyEntity>()
                .RuleFor(p => p.Id, f => 0)
                .RuleFor(p => p.Name, f =>
                {
                    string name;
                    do
                    {
                        name = f.Company.CompanyName();
                    } while (!generatedNames.Add(name));
                    return name;
                })
                .RuleFor(p => p.Description, f => f.Company.CompanySuffix())
                .RuleFor(p => p.LicenseNumber, f =>
                {
                    string license;
                    do
                    {
                        license = f.Random.Replace("###-###-####");
                    } while (!generatedLicenseNumbers.Add(license));
                    return license;
                })
                .RuleFor(p => p.CreatedTime, f => DateTime.UtcNow)
                .RuleFor(p => p.Status, f => EEntityStatus.Active)
                .RuleFor(p => p.PharmacyBranchEntities, f =>
                {
                    return branchFaker.Generate(f.Random.Int(1, 5));
                });

            List<PharmacyEntity> addedPharmacyEntities = pharmacyFaker.Generate(count);
            await _unitOfWork.PharmacyWriteRepository.AddManyAsync(addedPharmacyEntities);
            return _unitOfWork.SaveChanges();


        }
        return 0;


    }
}
