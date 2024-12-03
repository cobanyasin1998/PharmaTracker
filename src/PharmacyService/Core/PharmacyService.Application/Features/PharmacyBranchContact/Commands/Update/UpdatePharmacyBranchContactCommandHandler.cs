using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;

public class UpdatePharmacyBranchContactCommandHandler : IRequestHandler<UpdatePharmacyBranchContactCommandRequest, IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePharmacyBranchContactCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);



        PharmacyBranchContactEntity? entity = await _unitOfWork.PharmacyBranchContactReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }



        entity.Type = request.Type;
        entity.Status = request.Status;
        entity.Value = request.Value;


        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchContactWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchContactCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
