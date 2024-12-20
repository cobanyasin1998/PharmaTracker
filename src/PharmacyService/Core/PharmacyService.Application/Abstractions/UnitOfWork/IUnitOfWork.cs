﻿using Coban.Application.Repositories.Base.Read;
using Coban.Application.Repositories.Base.Write;
using Coban.Application.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Abstractions.UnitOfWork;
public interface IUnitOfWork: IUnitOfWorkTransaction
{
  
    //Pharmacy Entity Repository
    IAsyncWriteRepository<PharmacyEntity> PharmacyWriteRepository { get; }
    IAsyncReadRepository<PharmacyEntity> PharmacyReadRepository { get; }

    //Pharmacy Branch Entity Repository
    IAsyncWriteRepository<PharmacyBranchEntity> PharmacyBranchWriteRepository { get; }
    IAsyncReadRepository<PharmacyBranchEntity> PharmacyBranchReadRepository { get; }

    //Pharmacy Branch Contact Entity Repository
    IAsyncWriteRepository<PharmacyBranchContactEntity> PharmacyBranchContactWriteRepository { get; }
    IAsyncReadRepository<PharmacyBranchContactEntity> PharmacyBranchContactReadRepository { get; }

    //Pharmacy Branch Address Entity Repository
    IAsyncWriteRepository<PharmacyBranchAddressEntity> PharmacyBranchAddressWriteRepository { get; }
    IAsyncReadRepository<PharmacyBranchAddressEntity> PharmacyBranchAddressReadRepository { get; }

}
