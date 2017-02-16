using System.Collections.Generic;
using vendor.logic.models.concretes;

namespace vendor.logic.models.abstracts
{
    public interface IValidationResult
    {
        ICollection<Validation> Validations { get; set; }
        bool IsValid { get; set; }
    }
}
