using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

public class ExampleCustomFilter
{
    private const string LicenseNumber = "LicenseNumber";
    private const string Eq = "equals";
    public static List<FilterGroup> ExampleFilter()
    {
        return new List<FilterGroup>();
    //    List<FilterGroup> filters = new List<FilterGroup>()
    //{
    //    new FilterGroup()
    //    {
    //        IntergroupLogic = "or",
    //        InterfilterOperator = "and",
    //        Filters = new List<Filter>() {
    //            new Filter()
    //            {
    //                Member = LicenseNumber,
    //                FilterValue = "965-187-3464",
    //                FilterOperator = Eq
    //            },
    //            new Filter()
    //            {
    //                Member = LicenseNumber,
    //                FilterValue = "",
    //                FilterOperator = "isnotnull"
    //            }
    //        }
    //    },
    //    new FilterGroup()
    //    {
    //        IntergroupLogic = "or",
    //        InterfilterOperator = "and",
    //        Filters = new List<Filter>()
    //        {
    //            new Filter()
    //            {
    //                Member = "Name",
    //                FilterValue = "string",
    //                FilterOperator = "notequals"
    //            },
    //            new Filter()
    //            {
    //                Member = LicenseNumber,
    //                FilterValue = "965-",
    //                FilterOperator = "startswith"
    //            }
    //        },
    //        ChildGroups = new List<FilterGroup>()
    //        {
    //            new FilterGroup()
    //            {
    //                IntergroupLogic = "and",
    //                InterfilterOperator = "or",
    //                Filters = new List<Filter>()
    //                {
    //                    new Filter()
    //                    {
    //                        Member = LicenseNumber,
    //                        FilterValue = "965-304-2032",
    //                        FilterOperator = Eq
    //                    },
    //                    new Filter()
    //                    {
    //                        Member = LicenseNumber,
    //                        FilterValue = "965-412-5388",
    //                        FilterOperator = Eq
    //                    }
    //                }
    //            },
    //            new FilterGroup()
    //            {
    //                IntergroupLogic = "and",
    //                InterfilterOperator = "or",
    //                Filters = new List<Filter>()
    //                {
    //                    new Filter()
    //                    {
    //                        Member = LicenseNumber,
    //                        FilterValue = "965",
    //                        FilterOperator = "equals"
    //                    },
    //                    new Filter()
    //                    {
    //                        Member = LicenseNumber,
    //                        FilterValue = "5388",
    //                        FilterOperator = "endswith"
    //                    }
    //                }
    //            }
    //        }
    //    }
    //};

    //    return filters;
    }
}