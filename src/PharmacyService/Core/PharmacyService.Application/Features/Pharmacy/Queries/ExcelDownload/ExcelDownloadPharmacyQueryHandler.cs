using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.ExcelDownload;

public class ExcelDownloadPharmacyQueryHandler : IRequestHandler<ExcelDownloadPharmacyQueryRequest, IResponse<ExcelDownloadPharmacyQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<ExcelDownloadPharmacyQueryResponse, GeneralErrorDto>> Handle(ExcelDownloadPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(1000);
        return Response<ExcelDownloadPharmacyQueryResponse, GeneralErrorDto>.CreateSuccess(
            new ExcelDownloadPharmacyQueryResponse()
            );

    }
}

