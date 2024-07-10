using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class StatusModelWithoutId
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        
        public int TypeId { get; set; }
       
    }
}
