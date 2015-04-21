using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikeRobbins.EntityServiceDemo.Attributes
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateProperty = (DateTime)value;

            DateTime dateNow = DateTime.Now;

            return dateProperty >= dateNow;
        }
    }
}