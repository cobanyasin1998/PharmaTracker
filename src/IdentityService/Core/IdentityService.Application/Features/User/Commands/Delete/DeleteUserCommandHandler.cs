using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Application.Features.User.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.Features.User.Commands.Delete;



public class DeleteUserCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteUserCommandRequest, IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<DeleteUserCommandResponse, GeneralErrorDto>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity? entity = await _unitOfWork.UserReadRepository
             .GetWhere(y => y.Id == request.Id, tracking: true)
             .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<DeleteUserCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(UserConstants.NotFound, ""));

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;

        _unitOfWork.UserWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<DeleteUserCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeleteUserCommandResponse(entity.Id), UserConstants.Deleted);
    }
}