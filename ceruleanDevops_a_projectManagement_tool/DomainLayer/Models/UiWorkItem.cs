using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPplication.UI.UiModels
{
    public class UIWorkItem
    {
        public string? WorkItemId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [NotWhiteSpace(ErrorMessage = "The field cannot be empty or contain only white spaces.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [NotZero(ErrorMessage = "Status cannot be zero.")]
        public int? StatusId { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [NotZero(ErrorMessage = "Type cannot be zero.")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [NotZero(ErrorMessage = "Priority cannot be zero.")]
        public int PriorityId { get; set; }

        [Required(ErrorMessage = "Area is required.")]
        [NotZero(ErrorMessage = "Area cannot be zero.")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Iteration is required.")]
        public int? IterationId { get; set; }

        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        [Required(ErrorMessage = "Assignee is required.")]
        public string AssigneeName { get; set; }

        [Required(ErrorMessage = "Reporter is required.")]
        public string ReporterName { get; set; }

        [Required(ErrorMessage = "StoryPoints is required.")]
        [NotZero(ErrorMessage = "StoryPoints cannot be zero.")]
        public int StoryPoints { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime ExpectedStartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime ExpectedEndDate { get; set; }
    }

    public class NotWhiteSpaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue && string.IsNullOrWhiteSpace(stringValue))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class NotZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue == 0)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}