using Coban.Application.Abstractions.Rules;

namespace PharmacyService.Application.Features.Pharmacy.Rules.Base;

public interface IPharmacyBusinessRule:IBaseBusinessRule
{
    Task IsPharmacyNameUnique(string Name);
    Task IsPharmacyNameUnique(string Name, long Id);
    Task IsPharmacyLicenseNumberUnique(string LicenseNumber);
    Task IsPharmacyLicenseNumberUnique(string LicenseNumber, long Id);

}
