using System.Collections.Generic;
using vendor.domain.entities;
using vendor.logic.models.concretes;

namespace vendor.logic.models.abstracts
{
    public interface IValidatorProduct
    {
        ValidationResult Validate(Product entry);
    }
}
