using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class FileModel
    {
        
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public long Size {  get; set; }
        public string WorkItemId { get; set; }
        public string SizeFormatted
        {
            get
            {
                if (Size >= 1048576)
                {
                    return $"{Size / 1048576.0:F2} MB";
                }
                else if (Size >= 1024)
                {
                    return $"{Size / 1024.0:F2} KB";
                }
                else
                {
                    return $"{Size} Bytes";
                }
            }
        }
    }
}
