 
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
     namespace WebAPplication.UI.NewFolder
    {
    public class NotWhiteSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return new ValidationResult("The field cannot be empty or contain only white spaces.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
