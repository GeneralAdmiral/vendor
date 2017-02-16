using vendor.domain.entities;
using vendor.logic.models.abstracts;

namespace vendor.logic.models.concretes
{
    public class ValidatorProduct : IValidatorProduct
    {
        private readonly IValidator _validator;
        private ValidationResult _result;

        public ValidatorProduct(IValidator validator)
        {
            this._validator = validator;
        }

        public virtual ValidationResult Validate(Product entry)
        {
            this._result = new ValidationResult() { IsValid = true };

            // this._validator.IsNullImage(entry.Image, _result);

            // this._validator.IsNullOrEmpty(entry.Name, _result);

            // this._validator.IsToDayUpDate(entry.Update, _result);

            return _result;
        }
    }
}
