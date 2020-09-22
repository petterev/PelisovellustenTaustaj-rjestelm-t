using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class PastDateAttribute : ValidationAttribute
{
    public void AddValidation(ClientModelValidationContext context)
    {
        throw new System.NotImplementedException();
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Item item = (Item)validationContext.ObjectInstance;
        if (item.CreationDate < DateTime.Now)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("error");
    }

    /* private ValidationResult GetErrorMessage()
     {
         throw new NotImplementedException();
     }*/
}
/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }
        }
    }
*/