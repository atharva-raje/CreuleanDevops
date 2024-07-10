using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IFileRepository
    {
        Task AddFileAsync(FileUploads fileUpload);
        Task<IEnumerable<FileUploads>> GetFilesByIdAsync(string id);
    }
}
