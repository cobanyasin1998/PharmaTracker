using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

public class ExampleCustomFilter
{
    private const string LicenseNumber = "LicenseNumber";
    private const string Name = "Name";
    private const string Eq = "equals";
    private const string NotEquals = "notequals";
    private const string StartsWith = "startswith";
    private const string EndsWith = "endswith";
    private const string IsNotNull = "isnotnull";
    private const string Or = "or";
    private const string And = "and";

    public static List<FilterGroup> ExampleFilter()
    {
        var filters = new List<FilterGroup>
        {
            new(
                filters:
                [
                    new() {
                        Member = LicenseNumber,
                        FilterValue = "965-187-3464",
                        FilterOperator = Eq
                    },
                    new() {
                        Member = LicenseNumber,
                        FilterValue = "",
                        FilterOperator = IsNotNull
                    }
                ],
                intergroupLogic: Or,
                interfilterOperator: And
            ),
            new FilterGroup(
                filters:
                [
                    new() {
                        Member = Name,
                        FilterValue = "string",
                        FilterOperator = NotEquals
                    },
                    new() {
                        Member = LicenseNumber,
                        FilterValue = "965-",
                        FilterOperator = StartsWith
                    }
                ],
                intergroupLogic: Or,
                interfilterOperator: And,
                childGroups:
                [
                    new(
                        filters:
                        [
                            new() {
                                Member = LicenseNumber,
                                FilterValue = "965-304-2032",
                                FilterOperator = Eq
                            },
                            new() {
                                Member = LicenseNumber,
                                FilterValue = "965-412-5388",
                                FilterOperator = Eq
                            }
                        ],
                        intergroupLogic: And,
                        interfilterOperator: Or
                    ),
                    new(
                        filters:
                        [
                            new() {
                                Member = LicenseNumber,
                                FilterValue = "965",
                                FilterOperator = Eq
                            },
                            new() {
                                Member = LicenseNumber,
                                FilterValue = "5388",
                                FilterOperator = EndsWith
                            }
                        ],
                        intergroupLogic: And,
                        interfilterOperator: Or
                    )
                ]
            )
        };

        return filters;
    }
}
