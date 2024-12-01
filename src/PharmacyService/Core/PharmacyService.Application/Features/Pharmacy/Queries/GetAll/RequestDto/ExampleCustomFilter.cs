using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

public class ExampleCustomFilter
{
    public List<FilterGroup> ExampleFilter()
    {
        var filters = new List<FilterGroup>()
    {
        new FilterGroup()
        {
            IntergroupLogic = "or",
            InterfilterOperator = "and",
            Filters = new List<Filter>() {
                new Filter()
                {
                    Member = "LicenseNumber",
                    FilterValue = "965-187-3464",
                    FilterOperator = "equals"
                },
                new Filter()
                {
                    Member = "LicenseNumber",
                    FilterValue = "",
                    FilterOperator = "isnotnull"
                }
            }
        },
        new FilterGroup()
        {
            IntergroupLogic = "or",
            InterfilterOperator = "and",
            Filters = new List<Filter>()
            {
                new Filter()
                {
                    Member = "Name",
                    FilterValue = "string",
                    FilterOperator = "notequals"
                },
                new Filter()
                {
                    Member = "LicenseNumber",
                    FilterValue = "965-",
                    FilterOperator = "startswith"
                }
            },
            ChildGroups = new List<FilterGroup>()
            {
                new FilterGroup()
                {
                    IntergroupLogic = "and",
                    InterfilterOperator = "or",
                    Filters = new List<Filter>()
                    {
                        new Filter()
                        {
                            Member = "licenseNumber",
                            FilterValue = "965-304-2032",
                            FilterOperator = "equals"
                        },
                        new Filter()
                        {
                            Member = "licenseNumber",
                            FilterValue = "965-412-5388",
                            FilterOperator = "equals"
                        }
                    }
                },
                new FilterGroup()
                {
                    IntergroupLogic = "and",
                    InterfilterOperator = "or",
                    Filters = new List<Filter>()
                    {
                        new Filter()
                        {
                            Member = "licenseNumber",
                            FilterValue = "965",
                            FilterOperator = "equals"
                        },
                        new Filter()
                        {
                            Member = "licenseNumber",
                            FilterValue = "5388",
                            FilterOperator = "endswith"
                        }
                    }
                }
            }
        }
    };

        return filters;
    }
}