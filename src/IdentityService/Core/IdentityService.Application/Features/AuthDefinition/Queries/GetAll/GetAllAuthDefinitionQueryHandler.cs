using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetAll;
public class GetAllAuthDefinitionQueryHandler : IRequestHandler<GetAllAuthDefinitionQueryRequest, IResponse<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    //private readonly IUnitOfWork _unitOfWork;
    public GetAllAuthDefinitionQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
        //_unitOfWork = unitOfWork;
    }
    public async Task<IResponse<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>> Handle(GetAllAuthDefinitionQueryRequest request, CancellationToken cancellationToken)
    {
      //  var entities = await _unitOfWork.AuthDefinitionReadRepository.GetAllAsync();
        return Response<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>
            .CreateSuccess(new GetAllAuthDefinitionQueryResponse(_mapper.Map<List<GetAllAuthDefinitionQueryResponseItemDto>>(entities)));
    }
}