using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;

public class UpdatePharmacyBranchCommandHandler : IRequestHandler<UpdatePharmacyBranchCommandRequest, IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePharmacyBranchCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        PharmacyBranchEntity? entity = await _unitOfWork.PharmacyBranchReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }

        entity.Name = request.Name;
        entity.Status = request.Status;
      
        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
