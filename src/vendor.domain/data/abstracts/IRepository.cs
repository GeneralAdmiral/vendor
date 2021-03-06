﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace vendor.domain.data.abstracts
{
    public interface IRepository<TEntity> :  IDisposable where TEntity : IEntity
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<TEntity> GetAsync(long entryId);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filer);

        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filer = null);

        Task<long> AddAsync(TEntity entry);

        Task<long> UpdateAsync(TEntity entry);

        Task<long> PutAsync(TEntity enty);

        Task<long> DeleteAsync(TEntity entry);

        Task<int> SaveChangesAsync();
    }
}
