namespace AuthModuleService.Application.Features.AuthModule.Commands.Create;



public class CreateAuthModuleCommandHandler : IRequestHandler<CreateAuthModuleCommandRequest, IResponse<CreateAuthModuleCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthModuleCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateAuthModuleCommandResponse, GeneralErrorDto>> Handle(CreateAuthModuleCommandRequest request, CancellationToken cancellationToken)
    {
       

        AuthModuleEntity entity = _mapper.Map<CreateAuthModuleCommandRequest, AuthModuleEntity>(request);

        await _unitOfWork.AuthModuleWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateAuthModuleCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateAuthModuleCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
