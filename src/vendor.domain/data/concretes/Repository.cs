using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using vendor.domain.data.abstracts;

namespace vendor.domain.data.concretes
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly VendorDbContext _context;
        private readonly DbSet<TEntity> _set;

        public Repository(VendorDbContext context)
        {
            this._context = context;
            this._set = _context.Set<TEntity>();
        }

        #region implementation IRepositoryAsync

        public async Task<TEntity> GetAsync(long entryId)
        {
            return await this._set.SingleOrDefaultAsync(x => x.Id == entryId);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await this._set.SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if(filter != null)
            {
                return await this._set.Where(filter).ToListAsync();
            }
            return await this._set.ToListAsync();
        }

        public async Task<long> AddAsync(TEntity entry)
        {
            if (entry.Id == 0)
            {
                entry.Id = this._set.Add(entry).Entity.Id;

                try
                {
                    var result = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return entry.Id;
        }

        public async Task<long> UpdateAsync(TEntity entry)
        {
            if (entry.Id >= 0)
            {
                entry.Id = this._set.Update(entry).Entity.Id;

                try
                {
                    var result = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return entry.Id;
        }

        public async Task<long> PutAsync(TEntity entry)
        {
            if (entry.Id >= 0)
            {
                _context.Entry(entry).State = EntityState.Modified;

                try
                {
                    var result = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return entry.Id;
        }

        public async Task<long> DeleteAsync(TEntity entry)
        {
            if (entry.Id >= 0)
            {
                entry.Id = this._set.Remove(entry).Entity.Id;

                try
                {
                    var result = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return entry.Id;
        }

        public EntityEntry<TDbSet> Entry<TDbSet>(TDbSet entity) where TDbSet : class
        {
            return this._context.Entry(entity);
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        #endregion

        #region Implementation IDispose, IQueryable, IEnamerable

        //public Expression Expression
        //{
        //    get
        //    {
        //        return this._context.Set<TEntity>().AsQueryable().Expression;
        //    }
        //}

        //public Type ElementType
        //{
        //    get
        //    {
        //        return this._context.Set<TEntity>().AsQueryable().ElementType;
        //    }
        //}

        //public IQueryProvider Provider
        //{
        //    get
        //    {
        //        return this._context.Set<TEntity>().AsQueryable().Provider;
        //    }
        //}

        public void Dispose()
        {
            this._context.Dispose();

            GC.SuppressFinalize(this);
        }

        //public IEnumerator<TEntity> GetEnumerator()
        //{
        //    return this._context.Set<TEntity>().ToList().GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this._context.Set<TEntity>().ToList().GetEnumerator();
        //}

        #endregion
    }
}
