using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetUserIdByName(string name);
    }
}
