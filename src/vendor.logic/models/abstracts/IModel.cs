using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace vendor.logic.models.abstracts
{
    public interface IModel<TEntity> : IDisposable where TEntity: class
    {
        DbSet<TEntity> Set { get; set; }
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null);
        bool Add(TEntity entry);
        bool Update(TEntity entry);
        bool Delete(long id);
        int SaveChange();
    }
}
