using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class WorkItem
    {
        [Key]
        [Required]
        public string WorkItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Types Type { get; set; }

        [Required]
        public int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public Priorities Priority { get; set; }

        [Required]
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public Areas Area { get; set; }

        [Required]
        public int IterationId { get; set; }
        [ForeignKey("IterationId")]
        public Iterations Iteration { get; set; }

        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AssigneeId { get; set; }
         
        public User Assignee { get; set; }
        [Required]
        [ForeignKey("User")]
        public int ReporterId { get; set; }
        public User Reporter { get; set; }
        public int StoryPoints {  get; set; }
        

        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<FileUploads> FileUploads { get; set; }
        public ICollection<WorkitemLink> SourceLinks { get; set; }
        public ICollection<WorkitemLink> TargetLinks { get; set; }

    }
}