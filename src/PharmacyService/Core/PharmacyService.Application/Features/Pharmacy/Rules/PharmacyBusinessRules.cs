using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;

namespace PharmacyService.Application.Features.Pharmacy.Rules;

public class PharmacyBusinessRules : IPharmacyBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;

    public PharmacyBusinessRules(IUnitOfWork unitOfWork) 
        => _unitOfWork = unitOfWork;

    public async Task IsPharmacyNameUnique(string Name)
    {
        bool isExists = await _unitOfWork.AsyncPharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.Name.ToLower() == Name.ToLower(),
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.PharmacyNameAlreadyExists);

    }
    public async Task IsPharmacyNameUnique(string Name, long Id)
    {
        bool isExists = await _unitOfWork.AsyncPharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.Name.ToLower() == Name.ToLower() && pharmacy.Id != Id,
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.PharmacyNameAlreadyExists);

    }
    public async Task IsPharmacyLicenseNumberUnique(string LicenseNumber)
    {
        bool isExists = await _unitOfWork.AsyncPharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.LicenseNumber.ToLower() == LicenseNumber.ToLower(),
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.PharmacyLicenseNumberAlreadyExists);

    }
    public async Task IsPharmacyLicenseNumberUnique(string LicenseNumber, long Id)
    {
        bool isExists = await _unitOfWork.AsyncPharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.LicenseNumber.ToLower() == LicenseNumber.ToLower() && pharmacy.Id != Id,
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.PharmacyLicenseNumberAlreadyExists);

    }
}





