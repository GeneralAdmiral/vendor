using System;
using System.Collections.Generic;
using vendor.logic.models.concretes;

namespace vendor.logic.models.abstracts
{
    public interface IValidator
    {
        ValidationResult IsToDayUpDate(DateTime entry, ValidationResult validResult);

        ValidationResult IsNullOrEmpty(string entry, ValidationResult validResult);

        ValidationResult IsNullImage(byte[] entry, ValidationResult validResult);
    }


}
