using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePharmacyCommandRequest, IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        PharmacyEntity? entity = await _unitOfWork.PharmacyReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<DeletePharmacyCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyConstants.NotFound, ""));

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;

        _unitOfWork.PharmacyWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<DeletePharmacyCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyCommandResponse(entity.Id), PharmacyConstants.Deleted);
    }
}
