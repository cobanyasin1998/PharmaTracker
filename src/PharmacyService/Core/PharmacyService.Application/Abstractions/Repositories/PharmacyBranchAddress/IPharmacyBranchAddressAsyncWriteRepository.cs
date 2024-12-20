﻿using Coban.Application.Repositories.Base.Write;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Abstractions.Repositories.PharmacyBranchAddress;

public interface IPharmacyBranchAddressAsyncWriteRepository : IAsyncWriteRepository<PharmacyBranchAddressEntity>
{
}
