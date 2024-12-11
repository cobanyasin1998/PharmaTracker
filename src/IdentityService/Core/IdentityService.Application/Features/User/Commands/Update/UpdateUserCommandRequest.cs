using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace IdentityService.Application.Features.User.Commands.Update;

public class UpdateUserCommandRequest : BaseRequest, IRequest<IResponse<UpdateUserCommandResponse, GeneralErrorDto>>
{

}