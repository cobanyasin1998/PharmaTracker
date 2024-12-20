﻿using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;

namespace PharmacyService.Application.Features.Pharmacy.Rules;

public class PharmacyBusinessRules(IUnitOfWork _unitOfWork) : IPharmacyBusinessRule
{
    public async Task IsPharmacyNameUnique(string Name)
    {
        bool isExists = await _unitOfWork.PharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.Name.ToLower() == Name.ToLower(),
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.NameAlreadyExists);

    }
    public async Task IsPharmacyNameUnique(string Name, long Id)
    {
        bool isExists = await _unitOfWork.PharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.Name.ToLower() == Name.ToLower() && pharmacy.Id != Id,
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.NameAlreadyExists);

    }
    public async Task IsPharmacyLicenseNumberUnique(string LicenseNumber)
    {
        bool isExists = await _unitOfWork.PharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.LicenseNumber.ToLower() == LicenseNumber.ToLower(),
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.LicenseNumberAlreadyExists);

    }
    public async Task IsPharmacyLicenseNumberUnique(string LicenseNumber, long Id)
    {
        bool isExists = await _unitOfWork.PharmacyReadRepository
            .GetWhere(
                predicate: pharmacy => pharmacy.LicenseNumber.ToLower() == LicenseNumber.ToLower() && pharmacy.Id != Id,
                tracking: false)
            .AnyAsync();

        if (isExists)
            throw new BusinessRuleException(PharmacyConstants.LicenseNumberAlreadyExists);

    }
}





