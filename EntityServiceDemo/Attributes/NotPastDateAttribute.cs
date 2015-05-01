using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikeRobbins.EntityServiceDemo.Attributes
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {    DateTime dateProperty = (DateTime)value;

            DateTime dateNow = DateTime.Now;

            if (dateProperty >= dateNow)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
                
            }
   
        }


    }
}