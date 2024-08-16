using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class WorkItemModel
    {

         
        [Required]
        public string WorkItemId { get; set; }
        [Required]
        public string Name { get; set; }
       

        public string? Description { get; set; }
        [Required]
        
        public int StatusId { get; set; }
         
        [Required]
        public int TypeId { get; set; }

        [Required]
        public int PriorityId { get; set; }
        [Required]
        
        public int AreaId { get; set; }
        [Required]
        
        public int IterationId { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
         
        [Required]
        public int AssigneeId { get; set; }
        public int ReporterId { get; set; }
        public int StoryPoints { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }

    }
}
