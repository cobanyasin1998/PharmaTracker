namespace UserGroupService.Application.Features.UserGroup.Commands.Update;



public class UpdateUserGroupCommandHandler : IRequestHandler<UpdateUserGroupCommandRequest, IResponse<UpdateUserGroupCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserGroupCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<UpdateUserGroupCommandResponse, GeneralErrorDto>> Handle(UpdateUserGroupCommandRequest request, CancellationToken cancellationToken)
    {
       
        UserGroupEntity entity = _mapper.Map<UpdateUserGroupCommandRequest, UserGroupEntity>(request);
        await _unitOfWork.UserGroupWriteRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<UpdateUserGroupCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdateUserGroupCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}