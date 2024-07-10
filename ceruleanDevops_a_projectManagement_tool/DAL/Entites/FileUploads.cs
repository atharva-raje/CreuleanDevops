using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class FileUploads
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public long Size { get; set; }
        // Foreign key to WorkItem
        public string WorkItemId { get; set; }
        public WorkItem WorkItem { get; set; }
    }
}
