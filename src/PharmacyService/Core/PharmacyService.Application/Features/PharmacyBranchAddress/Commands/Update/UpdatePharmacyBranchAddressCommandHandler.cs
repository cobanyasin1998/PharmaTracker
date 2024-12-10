using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchAddress.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdatePharmacyBranchAddressCommandRequest, IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {

        PharmacyBranchAddressEntity? entity = await _unitOfWork.PharmacyBranchAddressReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchAddressConstants.NotFound, ""));

        _mapper.Map(request, entity);

        _unitOfWork.PharmacyBranchAddressWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchAddressCommandResponse(entity.Id), PharmacyBranchAddressConstants.Updated);
    }
}