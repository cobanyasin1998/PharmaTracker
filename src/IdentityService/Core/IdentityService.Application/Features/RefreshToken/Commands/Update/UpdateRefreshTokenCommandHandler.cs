namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Update;



public class UpdateRefreshTokenCommandHandler : IRequestHandler<UpdateRefreshTokenCommandRequest, IResponse<UpdateRefreshTokenCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateRefreshTokenCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<UpdateRefreshTokenCommandResponse, GeneralErrorDto>> Handle(UpdateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
       
        RefreshTokenEntity entity = _mapper.Map<UpdateRefreshTokenCommandRequest, RefreshTokenEntity>(request);
        await _unitOfWork.RefreshTokenWriteRepository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<UpdateRefreshTokenCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdateRefreshTokenCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}