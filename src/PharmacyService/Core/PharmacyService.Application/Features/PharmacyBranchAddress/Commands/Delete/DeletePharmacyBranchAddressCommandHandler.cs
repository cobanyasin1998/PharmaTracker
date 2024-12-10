using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchAddress.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;



public class DeletePharmacyBranchAddressCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePharmacyBranchAddressCommandRequest, IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchAddressEntity? entity = await _unitOfWork.PharmacyBranchAddressReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchAddressConstants.NotFound, ""));

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;

        _unitOfWork.PharmacyBranchAddressWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchAddressCommandResponse(entity.Id), PharmacyBranchAddressConstants.Deleted);
    }
}