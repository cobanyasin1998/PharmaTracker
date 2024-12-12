using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.SyncDto.Identity.User;

namespace IdentityService.Application.Features.Comm.Queries.GetByBasicUserId;

public class GetByBasicUserIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetByBasicUserIdQueryRequest, IResponse<GetByBasicUserIdQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByBasicUserIdQueryResponse, GeneralErrorDto>> Handle(GetByBasicUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        UserEntity? user = await _unitOfWork.UserReadRepository.GetWhere(y => y.Id == request.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (user is null)
        {
            return Response<GetByBasicUserIdQueryResponse, GeneralErrorDto>
                .CreateFailureGetByIdNotFound(new GeneralErrorDto("NotFoundUser", ""));
        }

        return Response<GetByBasicUserIdQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetByBasicUserIdQueryResponse() { FirstName = user.FirstName, LastName = user.LastName });
    }
}
