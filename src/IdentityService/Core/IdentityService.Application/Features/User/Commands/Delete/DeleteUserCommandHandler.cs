namespace UserService.Application.Features.User.Commands.Delete;



public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<DeleteUserCommandResponse, GeneralErrorDto>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
       
        await _unitOfWork.UserWriteRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<DeleteUserCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeleteUserCommandResponse());
    }
}