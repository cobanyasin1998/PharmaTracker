using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Delete;

public class DeleteAuthFormCommandRequest : IRequest<IResponse<DeleteAuthFormCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}