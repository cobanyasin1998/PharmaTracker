namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Delete;



public class DeleteRefreshTokenCommandHandler : IRequestHandler<DeleteRefreshTokenCommandRequest, IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteRefreshTokenCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>> Handle(DeleteRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
       
        await _unitOfWork.RefreshTokenWriteRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<DeleteRefreshTokenCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeleteRefreshTokenCommandResponse());
    }
}