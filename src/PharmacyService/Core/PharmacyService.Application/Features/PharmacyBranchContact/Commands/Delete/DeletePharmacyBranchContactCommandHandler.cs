using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Features.Pharmacy.Commands.Delete;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;

public class DeletePharmacyBranchContactCommandHandler : IRequestHandler<DeletePharmacyBranchContactCommandRequest, IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePharmacyBranchContactCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        PharmacyBranchContactEntity? entity = await _unitOfWork.PharmacyBranchContactReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;



        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchContactWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchContactCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
