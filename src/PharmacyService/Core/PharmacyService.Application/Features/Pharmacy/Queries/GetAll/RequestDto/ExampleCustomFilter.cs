//var filters = new List<FilterGroup>();

//filters.Add(new FilterGroup()
//{
//    IntergroupLogic = "or",
//    InterfilterOperator = "and",
//    Filters = new List<Filter>() {

//        new Filter()
//        {
//            Member = "Name",
//            FilterValue = "string",
//            FilterOperator = "notequals"
//        },
//        new Filter()
//        {
//            Member = "LicenseNumber",
//            FilterValue = "965-",
//            FilterOperator = "startswith"
//        }
//    },
//    ChildGroups = new List<FilterGroup>()
//    {
//        new FilterGroup()
//        {
//            IntergroupLogic = "and",
//            InterfilterOperator = "or",
//            Filters = new List<Filter>()
//            {
//                new Filter()
//                {
//                    Member = "licenseNumber",
//                    FilterValue = "965-304-2032",
//                    FilterOperator = "equals"
//                },
//                new Filter()
//                {
//                    Member = "licenseNumber",
//                    FilterValue = "965-412-5388",
//                    FilterOperator = "equals"
//                }
//            }
//        },
//        new FilterGroup()
//        {
//           IntergroupLogic = "and",
//            InterfilterOperator = "or",
//            Filters = new List<Filter>()
//            {
//                new Filter()
//                {
//                    Member = "licenseNumber",
//                    FilterValue = "965",
//                    FilterOperator = "equals"
//                },
//                new Filter()
//                {
//                    Member = "licenseNumber",
//                    FilterValue = "5388",
//                    FilterOperator = "endswith"
//                }
//            }
//        }
//    }
//});
//filters.Add(new FilterGroup()
//{

//    IntergroupLogic = "or",
//    InterfilterOperator = "and",
//    Filters = new List<Filter>() {

//        new Filter()
//        {
//            Member = "LicenseNumber",
//            FilterValue = "965-187-3464",
//            FilterOperator = "equals"
//        },
//        new Filter()
//        {
//            Member = "LicenseNumber",
//            FilterValue = "",
//            FilterOperator = "isnotnull"
//        }
//    },

//}
//);
