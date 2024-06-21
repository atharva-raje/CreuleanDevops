using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public Task<Comments> AddComment(Comments comments)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comments>> GetComments()
        {
            return await _workItemsDbContext.Comments.ToListAsync(); 
        }
    }
}
