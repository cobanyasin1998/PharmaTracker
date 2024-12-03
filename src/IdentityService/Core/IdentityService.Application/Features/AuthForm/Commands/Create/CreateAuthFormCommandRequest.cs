using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Create;

public class CreateAuthFormCommandRequest : IRequest<IResponse<CreateAuthFormCommandResponse, GeneralErrorDto>>
{
   
}