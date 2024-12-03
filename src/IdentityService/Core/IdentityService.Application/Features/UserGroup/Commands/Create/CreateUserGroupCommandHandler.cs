namespace UserGroupService.Application.Features.UserGroup.Commands.Create;



public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommandRequest, IResponse<CreateUserGroupCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserGroupCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateUserGroupCommandResponse, GeneralErrorDto>> Handle(CreateUserGroupCommandRequest request, CancellationToken cancellationToken)
    {
       

        UserGroupEntity entity = _mapper.Map<CreateUserGroupCommandRequest, UserGroupEntity>(request);

        await _unitOfWork.UserGroupWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateUserGroupCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateUserGroupCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
