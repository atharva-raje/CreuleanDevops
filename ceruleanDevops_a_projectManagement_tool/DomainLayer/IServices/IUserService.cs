using DAL.Entites;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IUserSerivce
    {
        Task<IEnumerable<User>> GetUsers();


    }
}
