﻿using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandHandler : IRequestHandler<CreatePharmacyBranchCommandRequest, IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
