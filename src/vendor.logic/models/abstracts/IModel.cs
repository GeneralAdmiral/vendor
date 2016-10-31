using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using vendor.domain.data.abstracts;

namespace vendor.logic.models.abstracts
{
    public interface IModel<T>
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> List(Expression<Func<T, bool>> filter = null);
        bool Add(T entry);
        bool Update(T entry);
        bool Delete();
        bool Validate(T entry);
    }
}
