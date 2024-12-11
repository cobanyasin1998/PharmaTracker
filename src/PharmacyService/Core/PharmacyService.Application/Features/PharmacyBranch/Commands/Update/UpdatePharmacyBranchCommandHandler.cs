using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;

public class UpdatePharmacyBranchCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdatePharmacyBranchCommandRequest, IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {

        PharmacyBranchEntity? entity = await _unitOfWork.PharmacyBranchReadRepository
            .GetWhere(y => y.Id == request.Id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            return Response<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchConstants.NotFound, ""));

        _mapper.Map(request, entity);

        _unitOfWork.PharmacyBranchWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchCommandResponse(entity.Id), PharmacyBranchConstants.Updated);
    }
}
