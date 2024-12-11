using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Application.Features.User.Constants;
using MediatR;

namespace IdentityService.Application.Features.User.Commands.Create;

public class CreateUserCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateUserCommandRequest, IResponse<CreateUserCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<CreateUserCommandResponse, GeneralErrorDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity entity = _mapper.Map<UserEntity>(request);

        await _unitOfWork.UserWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateUserCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateUserCommandResponse(entity.Id), UserConstants.Created);
    }
}
