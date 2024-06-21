using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public  class CommentModel
    {
        public string decription { get; set; }
        public DateTime dateTime { get; set; }
        public int userid { get; set; }
    }
}
