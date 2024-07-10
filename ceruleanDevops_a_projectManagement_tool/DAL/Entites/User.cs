using System.ComponentModel.DataAnnotations;

namespace DAL.Entites
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Comments> Comments{ get; set; }
        public ICollection<WorkItem> WorkItems{ get; set; }

    }
}