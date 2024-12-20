﻿using Coban.Domain.Entities.Base;

namespace Coban.Application.Repositories.Base.Write;

public interface IAsyncWriteRepository<in T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task AddManyAsync(IEnumerable<T> entities);
    bool Update(T entity);
    void UpdateMany(IEnumerable<T> entities);
    bool Delete(T entity);
    void DeleteMany(IEnumerable<T> entities);
}
