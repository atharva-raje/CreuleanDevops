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

        public async Task<bool> DeletefileAsync(int id)
        {
            var result = await _workItemsDbContext.Files
                 .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _workItemsDbContext.Files.Remove(result);
                await _workItemsDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<FileUploads> GetFilesByFileIdAsync(int id)
        {
            return await _workItemsDbContext.Files.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<FileUploads>> GetFilesByIdAsync(string WorkItemid)
        {
            return await _workItemsDbContext.Files.Where(f => f.WorkItemId == WorkItemid).ToListAsync();
        }
    }
}
