using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class FileModelWithoutData
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadDate { get; set; }
        public long Size { get; set; }
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

