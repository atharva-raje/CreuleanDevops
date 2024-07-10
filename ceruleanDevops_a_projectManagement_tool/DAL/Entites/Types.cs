using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Types
    {
        [Key]
        public int  TypeId {  get; set; }
        public string TypeName { get; set; }
        public ICollection<WorkItem> WorkItems { get; set; }
        public ICollection<Status> statuses { get; set; }
    }
}
