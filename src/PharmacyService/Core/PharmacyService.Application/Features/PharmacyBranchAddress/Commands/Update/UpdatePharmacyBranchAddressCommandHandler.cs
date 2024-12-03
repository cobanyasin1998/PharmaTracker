using Coban.Application.Abstractions.Rules;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandHandler : IRequestHandler<UpdatePharmacyBranchAddressCommandRequest, IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePharmacyBranchAddressCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);



        PharmacyBranchAddressEntity? entity = await _unitOfWork.PharmacyBranchAddressReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }



        entity.Status = request.Status;
        entity.Latitude = request.Latitude;
        entity.Longitude = request.Longitude;
        entity.Address = request.Address;
        entity.NeighbourhoodId = request.NeighbourhoodId;
        entity.StreetId = request.StreetId;
        entity.DistrictId = request.DistrictId;
        entity.ProvinceId = request.ProvinceId;
        entity.IsPrimary = request.IsPrimary;



        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchAddressWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyBranchAddressCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
