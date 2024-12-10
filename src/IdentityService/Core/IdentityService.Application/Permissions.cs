namespace IdentityService.Application;

//public enum Modules
//{
//    Pharmacy = 100
//}
//public enum 
//public enum EPermissions
//{
//    Menu = 100,
//    Read = 101,
//    Create = 102,
//    Update = 103,
//    Delete = 104,  
//    Print = 105,
//    Export = 106,
//    Import = 107
//}
public static class PharmacyPermissions
{
    private const int PharmacyModule = 100;

    public static class Pharmacy
    {
        private const int Base = PharmacyModule + 0;

        public static readonly Permission PharmacyForm = new(Base + 1, "PharmacyForm");
        public static readonly Permission PharmacyBranchForm = new(Base + 2, "PharmacyBranchForm");
        public static readonly Permission PharmacyBranchContactForm = new(Base + 3, "PharmacyBranchContactForm");
        public static readonly Permission PharmacyBranchAddressForm = new(Base + 4, "PharmacyBranchAddressForm");

        public static class Actions
        {
            private const int ActionBase = PharmacyModule + 100;

            public static readonly Permission Menu = new(ActionBase + 1, "Menu");
            public static readonly Permission Read = new(ActionBase + 2, "Read");
            public static readonly Permission Create = new(ActionBase + 3, "Create");
            public static readonly Permission Update = new(ActionBase + 4, "Update");
            public static readonly Permission Delete = new(ActionBase + 5, "Delete");
            public static readonly Permission Print = new(ActionBase + 6, "Print");
            public static readonly Permission Export = new(ActionBase + 7, "Export");
            public static readonly Permission Import = new(ActionBase + 8, "Import");
        }
    }

    public record Permission(int Code, string Name);
}
