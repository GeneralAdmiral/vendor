
using System;
using System.Collections;
using System.Collections.Generic;
using vendor.domain.entities;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class Validator : IValidator
    { 
        public ValidationResult IsToDayUpDate(DateTime entry, ValidationResult validResult)
        {
            if (!entry.Day.Equals(DateTime.Now.Day))
            {
                validResult.IsValid = false;

                validResult.Validations.Add(new Validation { Message = "UpDate incorrect." });
            }

            return validResult;
        }

        public ValidationResult IsNullOrEmpty(string entry, ValidationResult validResult)
        {
            if (string.IsNullOrEmpty(entry))
            {
                validResult.IsValid = false;

                validResult.Validations.Add(new Validation { Message = "Name of product must be set." });
            }

            return validResult;
        }

        public ValidationResult IsNullImage(byte[] entry, ValidationResult validResult)
        {
            if (entry == null)
            {
                validResult.IsValid = false;

                validResult.Validations.Add(new Validation { Message = "Image must be set." });
            }

            return validResult;
        }
    }
}
