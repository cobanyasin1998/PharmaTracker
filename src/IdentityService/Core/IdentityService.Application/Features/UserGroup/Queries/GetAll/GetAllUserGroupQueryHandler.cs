namespace UserGroupService.Application.Features.UserGroup.Queries.GetAll;



public class GetAllUserGroupQueryHandler : IRequestHandler<GetAllUserGroupQueryRequest, IResponse<GetAllUserGroupQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllUserGroupQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<GetAllUserGroupQueryResponse, GeneralErrorDto>> Handle(GetAllUserGroupQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.UserGroupReadRepository.GetAllAsync();
        return Response<GetAllUserGroupQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetAllUserGroupQueryResponse(_mapper.Map<List<GetAllUserGroupQueryResponseItemDto>>(entities)));
    }
}