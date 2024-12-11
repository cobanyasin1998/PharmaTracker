
using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Application.Features.User.Constants;
using MediatR;

namespace IdentityService.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetByIdUserQueryRequest, IResponse<GetByIdUserQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdUserQueryResponse, GeneralErrorDto>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        UserEntity? userEntity = await _unitOfWork.UserReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (userEntity is null)
            return Response<GetByIdUserQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(UserConstants.NotFound, ""));

        GetByIdUserQueryResponse getByIdUserQueryResponse = _mapper.Map<GetByIdUserQueryResponse>(userEntity);

        return Response<GetByIdUserQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdUserQueryResponse);
    }
}
