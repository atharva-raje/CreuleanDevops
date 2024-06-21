using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public  interface IcommentRepository
    {
        Task<Comments> AddComment(Comments comments);
        Task<IEnumerable<Comments>> GetComments();

    }
}
