using System.Collections.Generic;
using vendor.logic.models.concretes;

namespace vendor.logic.models.abstracts
{
    public interface IResult<T>
    {
        ICollection<T> Results { get; set; }

        ValidationResult Error { get; set; }
    }
}
