using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class PastDateAttribute : ValidationAttribute
{

    public string GetErrorMessage() => "Date error";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateTime = (DateTime)validationContext.ObjectInstance;
        if (dateTime != DateTime.Now)
        {
            return new ValidationResult(GetErrorMessage());
        }
        return ValidationResult.Success;
    }

}