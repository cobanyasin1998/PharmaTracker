namespace PharmacyService.Persistence.Consts;

public static class PharmacyPersistenceConsts
{
    #region Pharmacy Entity
    public static readonly string Pharmacies = "Pharmacies";
    public static readonly string PharmaciesNameIndex = "IX_Pharmacies_Name";
    public static readonly string PharmaciesStatusIndex = "IX_Pharmacies_Status";
    #endregion

    #region Pharmacy Branch Entity
    public static readonly string PharmacyBranches = "PharmacyBranches";
    public static readonly string PharmacyBranchesNameIndex = "IX_PharmacyBranches_BranchName";
    public static readonly string PharmacyBranchesStatusIndex = "IX_PharmacyBranches_Status";

    #endregion

    #region Pharmacy Branch Contact Entity
    public static readonly string PharmacyBranchContacts = "PharmacyBranchContacts";
    public static readonly string PharmacyBranchContactsStatusIndex = "IX_PharmacyBranchContacts_Status";
    #endregion

    #region Pharmacy Branch Address Entity
    public static readonly string PharmacyBranchAddresses = "PharmacyBranchAddresses";
    public static readonly string PharmacyBranchAddressStatusIndex = "IX_PharmacyBranchAddresses_Status";
    #endregion



}
