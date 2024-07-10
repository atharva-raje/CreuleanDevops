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
    public class UserRepository : IUserRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public UserRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int UserId)
        {
            return await _workItemsDbContext.Users.FirstOrDefaultAsync(u => u.UserId == UserId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _workItemsDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserIdByName(string name)
        {
            return await _workItemsDbContext.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
