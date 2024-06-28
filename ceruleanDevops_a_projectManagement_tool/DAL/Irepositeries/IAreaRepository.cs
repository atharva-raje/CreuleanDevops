using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Areas>> GetAreas();
        Task<Areas> GetAreaId(string name);

    }
}
