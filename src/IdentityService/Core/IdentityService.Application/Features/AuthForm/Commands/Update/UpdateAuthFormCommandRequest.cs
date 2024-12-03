using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Update;

public class UpdateAuthFormCommandRequest : IRequest<IResponse<UpdateAuthFormCommandResponse, GeneralErrorDto>>
{
   
}