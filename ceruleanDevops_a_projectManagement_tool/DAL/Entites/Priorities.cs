using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
     public class Priorities
    {
        [Key]
        public int  PriorityId {  get; set; }
        public string PritoryName {  get; set; }
        public ICollection<WorkItem> WorkItems { get; set; }
        
    }
}
