using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class WorkItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Status")]
        public int statusId { get; set; }
        public Status status { get; set; }
        
        public string Type { get; set; }
        public string priority { get; set; }
        public string area { get; set; }
        public string iteration {  get; set; }
        public DateTime startDate {  get; set; }
        public DateTime endDate { get; set; }
        public string user {  get; set; }
        public ICollection<Comments> comments { get; set; }

    }
}
