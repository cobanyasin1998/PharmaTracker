using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Application.Features.Pharmacy.Queries.ExcelDownload;

public class ExcelDownloadPharmacyQueryRequest : IRequest<IResponse<ExcelDownloadPharmacyQueryResponse, GeneralErrorDto>>
{

}
