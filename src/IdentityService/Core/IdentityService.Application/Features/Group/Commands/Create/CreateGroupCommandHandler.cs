namespace GroupService.Application.Features.Group.Commands.Create;



public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, IResponse<CreateGroupCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGroupCommandHandler(IMapper mapper, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreateGroupCommandResponse, GeneralErrorDto>> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
    {
       

        GroupEntity entity = _mapper.Map<CreateGroupCommandRequest, GroupEntity>(request);

        await _unitOfWork.GroupWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreateGroupCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreateGroupCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
