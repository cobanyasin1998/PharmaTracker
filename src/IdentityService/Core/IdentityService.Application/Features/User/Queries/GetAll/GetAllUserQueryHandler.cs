using Coban.Application.DataProtection.Abstractions;
using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Abstractions.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.Features.User.Queries.GetAll;



public class GetAllUserQueryHandler(IDataProtectService _dataProtectService, IUnitOfWork _unitOfWork) : IRequestHandler<GetAllUserQueryRequest, IResponse<GetAllUserQueryResponse, GeneralErrorDto>>
{

    public async Task<IResponse<GetAllUserQueryResponse, GeneralErrorDto>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<UserEntity>? query = _unitOfWork.UserReadRepository.GetAll(tracking: false);

        List<GetAllUserQueryResponseItemDto> UserList = await query
      
        
            .Select(p => new GetAllUserQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                FirstName = p.FirstName,
              
            })       
            .ApplyPaging(pageNumber: request.Paging.Page, request.Paging.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();
        return Response<GetAllUserQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllUserQueryResponse
        {
            TotalCount = totalCount,
            Result = UserList,
            TotalPage = (int)Math.Ceiling((double)totalCount / UserList.Count)
        });
    }
}
