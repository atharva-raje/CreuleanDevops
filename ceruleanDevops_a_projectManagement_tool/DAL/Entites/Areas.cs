using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public  class Areas
    {
       
        public int Id { get; set; }
        public string AreaName { get; set; }
        public ICollection<Iterations> Iterations { get; set; }
        public ICollection<WorkItem> WorkItems { get; set; }    
    }
}
