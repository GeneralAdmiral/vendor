using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using vendor.domain.data.abstracts;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class Model<TEntity> : IModel<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public Model(IRepository<TEntity> repository)
        {
            this._repository = repository;

            this.Set = this._repository.Set<TEntity>();
        }

        public DbSet<TEntity> Set { get; set; }

        private TEntity single(Expression<Func<TEntity, bool>> filter, Func<Expression<Func<TEntity, bool>>, Task<TEntity>> func)
        {
            return Task.FromResult(func(filter)).Result.Result;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.single(filter, this._repository.GetAsync);
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null)
        {
            return Task.FromResult(this._repository.ListAsync(filter)).Result.Result;
        }

        public bool Add(TEntity entry)
        {
            var _entry = this.single(x => x.Id == entry.Id, this._repository.GetAsync);
            if (_entry == null && Task.FromResult(this._repository.AddAsync(entry)).Result.Result > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(long id)
        {
            var entry = this.single(x => x.Id == id, this._repository.GetAsync);
            if (entry != null && Task.FromResult(this._repository.DeleteAsync(entry)).Result.Result > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(TEntity entry)
        {
            var _entry = this.single(x => x.Id == entry.Id, this._repository.GetAsync);
            if (entry != null && Task.FromResult(this._repository.UpdateAsync(entry)).Result.Result > 0)
            {
                return true;
            }
            return false;
        }

        public int SaveChange()
        {
            return this._repository.SaveChangesAsync().Result;
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
