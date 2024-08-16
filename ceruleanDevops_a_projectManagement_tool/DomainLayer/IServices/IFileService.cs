using DAL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IFileService
    {
        Task<bool> UploadFilesAsync(List<IFormFile> files, string workItemId);
        Task<IEnumerable<FileUploads>> GetFilesWithId(string id);
        Task<FileUploads> GetFileByFileId(int id);
        Task<bool>  Deletefile(int id);
    }
}
