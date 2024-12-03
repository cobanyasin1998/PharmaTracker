namespace UserService.Application.Features.User.Commands.Create;



public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, IResponse<CreateUserCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateUserCommandResponse, GeneralErrorDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
       

        UserEntity entity = _mapper.Map<CreateUserCommandRequest, UserEntity>(request);

        await _unitOfWork.UserWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateUserCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateUserCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
