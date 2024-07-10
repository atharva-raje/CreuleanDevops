using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositeries
{
    public class FileRepository : IFileRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public FileRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }

        public async Task AddFileAsync(FileUploads fileUpload)
        {
            await _workItemsDbContext.Files.AddAsync(fileUpload);
            await _workItemsDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FileUploads>> GetFilesByIdAsync(string WorkItemid)
        {
            return await _workItemsDbContext.Files.Where(f => f.WorkItemId == WorkItemid).ToListAsync();
        }
    }
}
