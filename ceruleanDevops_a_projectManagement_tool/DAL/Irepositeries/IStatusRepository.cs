using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IStatusRepository
    {
        Task<Status> GetStatusId(string name);
        Task<IEnumerable<Status>> GetStatuses();
        Task<Status> GetStatusName(int  statusId);
    }
}
