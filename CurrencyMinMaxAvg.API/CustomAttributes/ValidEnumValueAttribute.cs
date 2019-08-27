using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMinMaxAvg.API.CustomAttributes
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enumType = value.GetType();
            var valid = Enum.IsDefined(enumType, value);

            if (!valid)
            {
                return new ValidationResult($"{value} is not a valid value for type {enumType.Name}.\n" +
                                            $"Valid values:{enumType.GetEnumValues()}");
            }

            return ValidationResult.Success;
        }
    }
}
