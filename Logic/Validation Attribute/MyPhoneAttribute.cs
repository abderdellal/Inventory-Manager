using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyPhoneAttribute : ValidationAttribute
    {
        private const string validephoneNumber = @"^\s*\+?\s*([0-9][\s-]*){9,}$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationNumber = (string)value;

            if (ErrorMessage == null) ErrorMessage = "This is not a valid phone number !";

            if (string.IsNullOrEmpty(validationNumber))
                return ValidationResult.Success;

            if (Regex.IsMatch(validationNumber, validephoneNumber))
            {
                return ValidationResult.Success;

            }


            return new ValidationResult(ErrorMessage);
        }
    }

}
