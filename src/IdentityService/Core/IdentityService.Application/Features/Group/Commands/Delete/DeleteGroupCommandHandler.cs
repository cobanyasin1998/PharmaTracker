namespace GroupService.Application.Features.Group.Commands.Delete;



public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommandRequest, IResponse<DeleteGroupCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteGroupCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<DeleteGroupCommandResponse, GeneralErrorDto>> Handle(DeleteGroupCommandRequest request, CancellationToken cancellationToken)
    {
       
        await _unitOfWork.GroupWriteRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<DeleteGroupCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeleteGroupCommandResponse());
    }
}