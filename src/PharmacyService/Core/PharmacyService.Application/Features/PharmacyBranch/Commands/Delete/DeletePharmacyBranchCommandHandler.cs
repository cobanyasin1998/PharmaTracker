﻿using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;

public class DeletePharmacyBranchCommandHandler : IRequestHandler<DeletePharmacyBranchCommandRequest, IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDataProtectService _dataProtectService;


    public DeletePharmacyBranchCommandHandler( IUnitOfWork unitOfWork, IDataProtectService dataProtectService)
    {
        _unitOfWork = unitOfWork;
        _dataProtectService = dataProtectService;
    }
    public async Task<IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        var entity = await _unitOfWork.PharmacyBranchReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null) 
        {
            throw new InvalidOperationException("Pharmacy Branch Not Found");
        }

        entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;



        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.PharmacyBranchWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<DeletePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new DeletePharmacyBranchCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
