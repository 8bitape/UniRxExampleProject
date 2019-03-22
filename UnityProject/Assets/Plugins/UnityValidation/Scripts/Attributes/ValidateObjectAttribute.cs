using System;
using System.ComponentModel.DataAnnotations;

namespace UnityValidation.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class ValidateObjectAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Validator.TryValidateObject(value);
        }
    }
}
