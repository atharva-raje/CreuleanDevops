using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using WebAPplication.UI.NewFolder;

namespace WebAPplication.UI.UiModels
{
    public class UIWorkItem
    { 
         
        public string? WorkItemId { get; set; }
        [NotNull]
        [NotWhiteSpace(ErrorMessage = "Title cannot be empty or contain only whitespace.")]
        [Required(ErrorMessage = "Title is required")]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
         
        [NotWhiteSpace(ErrorMessage = "Status cannot be empty or contain only whitespace.")]
        [Required(ErrorMessage = "Status is required")]
        public int? StatusId { get; set; }
        [NotNull]
        [NotWhiteSpace(ErrorMessage = "Type cannot be empty or contain only whitespace.")]
        [Required(ErrorMessage = "Type is required")]
        public int TypeId { get; set; }

        public int PriorityId { get; set; }
        [NotNull]
        [NotWhiteSpace(ErrorMessage = "Area cannot be empty or contain only whitespace.")]
        [Required(ErrorMessage = "Area is required")]

        public int AreaId { get; set; }
        
        
        [NotWhiteSpace(ErrorMessage = "iteration cannot be empty or contain only whitespace.")]
        [Required(ErrorMessage = "iteration is required")]

        public int? IterationId { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        
        public string AssigneeName{ get; set; }
        public string ReporterName {  get; set; }
        public int StoryPoints {  get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }

    }

}
