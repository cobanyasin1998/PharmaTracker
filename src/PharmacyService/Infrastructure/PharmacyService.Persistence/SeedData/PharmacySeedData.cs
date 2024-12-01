using Bogus;
using Coban.Domain.Enums.Base;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Coban.Persistence.SeedData.Abstractions;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;

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
            var generatedLicenseNumbers = new HashSet<string>();
            var generatedNames = new HashSet<string>();


            var pharmacyFaker = new Faker<PharmacyEntity>()
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
                .RuleFor(p => p.CreatedUserId, f => f.Random.Int(1, 100))
                .RuleFor(p => p.Status, f => EEntityStatus.Active);

            var addedPharmacyEntities = pharmacyFaker.Generate(count);
            await _unitOfWork.PharmacyWriteRepository.AddManyAsync(addedPharmacyEntities);
            return _unitOfWork.SaveChanges();
        }
        return 0;


    }
}
