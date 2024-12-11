namespace PharmaGateway.API.Routes.PharmacyService.Pharmacy.Consts;

public static class RouteConsts
{
    public const string PharmacyPrefix = "pharmacy";
    public const string PharmacyFullAddress = "https://localhost:7901/";
    public const string PharmacyClusterName = $"{PharmacyPrefix}Cluster";

    public const string PharmacyCreate = $"/Pharmacy/Create";
    public const string PharmacyUpdate = $"/Pharmacy/Update";
    public const string PharmacyGetAll = $"/Pharmacy/GetAll";

    public const string PharmacyCreatePrefix = $"{PharmacyPrefix}Create";
    public const string PharmacyUpdatePrefix = $"{PharmacyPrefix}Update";
    public const string PharmacyGetAllPrefix = $"{PharmacyPrefix}GetAll";
}
