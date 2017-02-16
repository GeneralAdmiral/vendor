using System.Collections.Generic;
using vendor.domain.entities;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class ResultProduct : IResult<Product>
    {
        public ICollection<Product> Results { get; set; } = new List<Product>();

        public ValidationResult Error { get; set; } = null;
    }
}
