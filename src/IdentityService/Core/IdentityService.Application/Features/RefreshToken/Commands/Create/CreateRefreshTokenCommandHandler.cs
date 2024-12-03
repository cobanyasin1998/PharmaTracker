namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Create;



public class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommandRequest, IResponse<CreateRefreshTokenCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRefreshTokenCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateRefreshTokenCommandResponse, GeneralErrorDto>> Handle(CreateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
       

        RefreshTokenEntity entity = _mapper.Map<CreateRefreshTokenCommandRequest, RefreshTokenEntity>(request);

        await _unitOfWork.RefreshTokenWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateRefreshTokenCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateRefreshTokenCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
