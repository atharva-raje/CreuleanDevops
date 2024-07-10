using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositeries
{
    public class CommentRepository : IcommentRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public CommentRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public async Task<Comments> AddComment(Comments comments)
        {
            var result = await _workItemsDbContext.Comments.AddAsync(comments);
            await _workItemsDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Comments>> GetCommentsById(string id)
        {
            return  await _workItemsDbContext.Comments.Where(u => u.WorkItemId == id).ToListAsync(); 
        }
    }
}
