using System.Collections.Generic;
using vendor.domain.entities.manytomany;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class ResultUserProduct : IResult<UserProduct>
        {
            public ICollection<UserProduct> Results { get; set; } = new List<UserProduct>();

            public ValidationResult Error { get; set; } = null;
        }
    }
