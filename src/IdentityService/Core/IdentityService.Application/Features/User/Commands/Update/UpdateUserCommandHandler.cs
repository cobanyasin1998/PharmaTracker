using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Application.Features.User.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.Features.User.Commands.Update;



public class UpdateUserCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) 
    : IRequestHandler<UpdateUserCommandRequest, IResponse<UpdateUserCommandResponse, GeneralErrorDto>>
{

    public async Task<IResponse<UpdateUserCommandResponse, GeneralErrorDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity? entity = await _unitOfWork.UserReadRepository
          .GetWhere(y => y.Id == request.Id, tracking: true)
          .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<UpdateUserCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(UserConstants.NotFound, ""));

        _mapper.Map(request, entity);

        _unitOfWork.UserWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<UpdateUserCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdateUserCommandResponse(entity.Id), UserConstants.Updated);
    }
}