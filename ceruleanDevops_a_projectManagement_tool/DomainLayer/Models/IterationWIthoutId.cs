using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class IterationWIthoutId
    {
        public int IterationId { get; set; }
        public string IterationName { get; set; }
        public int AreaId { get; set; }
    }
}
