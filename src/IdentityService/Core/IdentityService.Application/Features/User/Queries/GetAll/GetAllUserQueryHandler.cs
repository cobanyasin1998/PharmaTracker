namespace UserService.Application.Features.User.Queries.GetAll;



public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IResponse<GetAllUserQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllUserQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<GetAllUserQueryResponse, GeneralErrorDto>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.UserReadRepository.GetAllAsync();
        return Response<GetAllUserQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetAllUserQueryResponse(_mapper.Map<List<GetAllUserQueryResponseItemDto>>(entities)));
    }
}