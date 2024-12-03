namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Create;



public class CreateAuthDefinitionCommandHandler : IRequestHandler<CreateAuthDefinitionCommandRequest, IResponse<CreateAuthDefinitionCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthDefinitionCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(CreateAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {
       

        AuthDefinitionEntity entity = _mapper.Map<CreateAuthDefinitionCommandRequest, AuthDefinitionEntity>(request);

        await _unitOfWork.AuthDefinitionWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateAuthDefinitionCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateAuthDefinitionCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
