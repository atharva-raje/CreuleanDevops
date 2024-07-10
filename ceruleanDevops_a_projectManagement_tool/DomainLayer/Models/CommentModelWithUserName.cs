using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class CommentModelWithUserName
    {

        [Required]
        public string decription { get; set; }
        public DateTime dateTime { get; set; }
        public string userName { get; set; }
        public int workItemId { get; set; }
    }
}
