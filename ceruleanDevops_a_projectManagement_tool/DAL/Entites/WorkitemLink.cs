using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
     
        public class WorkitemLink
        {
        [Key]
        public int Id { get; set; }
            
        [ForeignKey("SourceWorkItemId")]
        [InverseProperty("SourceLinks")]
        public string SourceWorkItemId { get; set; }
        public WorkItem SourceWorkItem { get; set; }
        [ForeignKey("TargetWorkItemId")]
        [InverseProperty("TargetLinks")]
        public string TargetWorkItemId { get; set; }
            public WorkItem TargetWorkItem { get; set; }
            public int LinkType { get; set; }
        }
    
}
