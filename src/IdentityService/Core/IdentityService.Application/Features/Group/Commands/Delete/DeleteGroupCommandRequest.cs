using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Delete;

public class DeleteGroupCommandRequest : IRequest<IResponse<DeleteGroupCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}