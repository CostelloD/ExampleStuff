using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestExamples.Models
{
    public class BirthDateAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object Date, ValidationContext validationContext)
        {
            Person Person  = (Person)validationContext.ObjectInstance;

            /*used AddYears method and current time to set values for the IF statement which checks the child is between
            3 and 5 years old on date of application*/
            DateTime start = DateTime.Today.AddYears(-5);
            DateTime end = DateTime.Today.AddYears(-2);

            if (Person.DateOfBirth < start | Person.DateOfBirth > end)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-BirthDate", GetErrorMessage());
        }


        private string GetErrorMessage()
        {
            return $"The Child must be aged between 3 and 5 years";
        }


    }
}
