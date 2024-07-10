using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class WorkItemModelWithString
    {
        [Required]
        public string WorkItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string StatusId { get; set; }

        [Required]
        public string TypeId { get; set; }

        [Required]
        public string PriorityId { get; set; }
        [Required]

        public string AreaId { get; set; }
        [Required]

        public string IterationId { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        [Required]
        public string UserId { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
    }
}
