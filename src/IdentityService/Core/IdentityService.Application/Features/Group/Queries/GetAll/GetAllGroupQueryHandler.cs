namespace GroupService.Application.Features.Group.Queries.GetAll;



public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQueryRequest, IResponse<GetAllGroupQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllGroupQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<GetAllGroupQueryResponse, GeneralErrorDto>> Handle(GetAllGroupQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.GroupReadRepository.GetAllAsync();
        return Response<GetAllGroupQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetAllGroupQueryResponse(_mapper.Map<List<GetAllGroupQueryResponseItemDto>>(entities)));
    }
}