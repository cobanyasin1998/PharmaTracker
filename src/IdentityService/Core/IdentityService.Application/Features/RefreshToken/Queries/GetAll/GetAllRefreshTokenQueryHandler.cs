namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetAll;



public class GetAllRefreshTokenQueryHandler : IRequestHandler<GetAllRefreshTokenQueryRequest, IResponse<GetAllRefreshTokenQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllRefreshTokenQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IResponse<GetAllRefreshTokenQueryResponse, GeneralErrorDto>> Handle(GetAllRefreshTokenQueryRequest request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.RefreshTokenReadRepository.GetAllAsync();
        return Response<GetAllRefreshTokenQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetAllRefreshTokenQueryResponse(_mapper.Map<List<GetAllRefreshTokenQueryResponseItemDto>>(entities)));
    }
}