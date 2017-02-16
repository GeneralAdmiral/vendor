using System;
using System.Linq.Expressions;
using vendor.domain.entities;
using vendor.logic.models.concretes;

namespace vendor.logic.models.abstracts
{
    public interface IModelProduct : IDisposable
    {
        ResultProduct Get(long id);

        ResultProduct List(Expression<Func<Product, bool>> filter = null);

        ResultProduct Add(Product entry);

        ResultProduct Update(Product entry, User user);

        ResultProduct Delete(long id);
    }
}
