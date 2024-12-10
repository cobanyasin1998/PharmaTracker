using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchContact.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;

public class UpdatePharmacyBranchContactCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdatePharmacyBranchContactCommandRequest, IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {

        PharmacyBranchContactEntity? entity = await _unitOfWork.PharmacyBranchContactReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchContactConstants.NotFound, ""));

        _mapper.Map(request, entity);

        _unitOfWork.PharmacyBranchContactWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchContactCommandResponse(entity.Id), PharmacyBranchContactConstants.Updated);
    }
}