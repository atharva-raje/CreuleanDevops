using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public  class Comments
    {
        
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public User User { get; set; }

        public string Description {  get; set; }
        public DateTime dateTime { get; set; }


    }
}
