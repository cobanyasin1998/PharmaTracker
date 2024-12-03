using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Commands.Delete;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;

public class DeletePharmacyBranchAddressCommandHandler : IRequestHandler<DeletePharmacyBranchAddressCommandRequest, IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePharmacyBranchAddressCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        PharmacyBranchAddressEntity? entity = await _unitOfWork.PharmacyBranchAddressReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;



        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchAddressWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchAddressCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
