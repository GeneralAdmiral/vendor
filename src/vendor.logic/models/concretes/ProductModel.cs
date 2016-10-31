using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using vendor.domain.data.abstracts;
using vendor.domain.entities;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class ProductModel : IProductModel
    {
        private readonly IRepository<Product> _repository;
        public ProductModel(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        //private Product Excute(Expression<Func<Product, bool>> filter)
        //{
        //    Func<Expression<Func<Product, bool>>, Product> p = () => _repository.GetAsync(filter);
        //    return Task.FromResult(filter).Result.Result;
        //}

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return Task.FromResult(this._repository.GetAsync(filter)).Result.Result;
        }

        public IEnumerable<Product> List(Expression<Func<Product, bool>> filter = null)
        {
            if (filter == null)
            {
                return Task.FromResult(this._repository.ListAsync()).Result.Result;
            }
            return Task.FromResult(this._repository.ListAsync(filter)).Result.Result;
        }

        public bool Add(Product entry)
        {
            var p = Task.FromResult(this._repository.AddAsync(entry)).Result.Result;

            if (p > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Product entry)
        {
             var p = Task.FromResult(this._repository.AddAsync(entry)).Result.Result;

            if (p > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Validate(Product entry)
        {
            return true;
        }
    }
}
