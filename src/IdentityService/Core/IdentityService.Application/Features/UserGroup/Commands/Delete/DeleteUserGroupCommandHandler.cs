namespace UserGroupService.Application.Features.UserGroup.Commands.Delete;



public class DeleteUserGroupCommandHandler : IRequestHandler<DeleteUserGroupCommandRequest, IResponse<DeleteUserGroupCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserGroupCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<DeleteUserGroupCommandResponse, GeneralErrorDto>> Handle(DeleteUserGroupCommandRequest request, CancellationToken cancellationToken)
    {
       
        await _unitOfWork.UserGroupWriteRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<DeleteUserGroupCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeleteUserGroupCommandResponse());
    }
}