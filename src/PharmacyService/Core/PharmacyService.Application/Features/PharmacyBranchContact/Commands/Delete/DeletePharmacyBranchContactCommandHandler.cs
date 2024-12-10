using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchContact.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;


public class DeletePharmacyBranchContactCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePharmacyBranchContactCommandRequest, IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchContactEntity? entity = await _unitOfWork.PharmacyBranchContactReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchContactConstants.NotFound, ""));

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;

        _unitOfWork.PharmacyBranchContactWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchContactCommandResponse(entity.Id), PharmacyBranchContactConstants.Deleted);
    }
}