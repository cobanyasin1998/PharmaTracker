using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.SyncCommunication;
using Coban.GeneralDto;
using MediatR;
using Newtonsoft.Json.Linq;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Domain.Entities;
using SharedLibrary.SyncDto.Identity.User;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork) 
    : IRequestHandler<GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyEntity? pharmacyEntity = await _unitOfWork.PharmacyReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (pharmacyEntity is null)
            return Response<GetByIdPharmacyQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyConstants.NotFound, ""));

        GetByIdPharmacyQueryResponse getByIdPharmacyQueryResponse = _mapper.Map<GetByIdPharmacyQueryResponse>(pharmacyEntity);

        var obj = new { 
            userId = 3//pharmacyEntity.CreatedUserId

        };
        
        Response<GetByBasicUserIdQueryResponse, GeneralErrorDto>? result = await DynamicHttpClient.SendRequestAsync<Response<GetByBasicUserIdQueryResponse, GeneralErrorDto>>
            ("https://localhost:7287/api/Comm/GetByUser", HttpMethod.Post, data: obj, token: null, cancellationToken: cancellationToken);

        if (result.Success && result?.Data is not null && result is not null)
        {
            getByIdPharmacyQueryResponse.FullCreatedName = $"{result.Data.FirstName} {result.Data.LastName}";
        }

        return Response<GetByIdPharmacyQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdPharmacyQueryResponse);
    }
}
