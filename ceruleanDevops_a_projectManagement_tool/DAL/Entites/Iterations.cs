using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Iterations
    {
        
        public int Id {  get; set; }   
        public string IterationName { get; set;}
        [ForeignKey("Areas")]
        public int AreaId {  get; set; }
        public Areas area { get; set; }
    }
}
