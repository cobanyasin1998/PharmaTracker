using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;

public class DeletePharmacyBranchCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePharmacyBranchCommandRequest, IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchEntity? entity = await _unitOfWork.PharmacyBranchReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<DeletePharmacyBranchCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchConstants.NotFound, ""));

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;

        _unitOfWork.PharmacyBranchWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<DeletePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchCommandResponse(entity.Id), PharmacyBranchConstants.Deleted);
    }
}