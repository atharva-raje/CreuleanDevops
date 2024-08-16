using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IAreaService
    {
        Task<IEnumerable<Areas>> GetAreas();
        Task<string> GetAreaName(int id);
        Task<int> GetAreaId(string name);
    }
}
