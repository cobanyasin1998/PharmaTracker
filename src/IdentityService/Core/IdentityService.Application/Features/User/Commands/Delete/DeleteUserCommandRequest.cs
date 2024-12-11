using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace IdentityService.Application.Features.User.Commands.Delete;

public class DeleteUserCommandRequest : BaseRequest, IRequest<IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
}