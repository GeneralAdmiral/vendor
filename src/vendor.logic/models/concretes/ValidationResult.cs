using System;
using System.Collections.Generic;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; } = true;
        public ICollection<Validation> Validations { get; set; } = new List<Validation>();
    }
}
