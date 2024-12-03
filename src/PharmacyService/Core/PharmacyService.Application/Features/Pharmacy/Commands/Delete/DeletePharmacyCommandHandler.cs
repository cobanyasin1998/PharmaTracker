using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandHandler : IRequestHandler<DeletePharmacyCommandRequest, IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePharmacyCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        PharmacyEntity? entity = await _unitOfWork.PharmacyReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;
       


        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<DeletePharmacyCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
