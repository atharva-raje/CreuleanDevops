using BusinessLOgic.Models;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IStatusService
    {
        Task<int> GetStatusId(string name);
        Task<IEnumerable<Status>> GetStatuses();
        Task<string> GetStatusName(int statusId);
        Task<IEnumerable<Status>> GetStatusByType(int typeid);

    }
}
