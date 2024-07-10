using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IIterationService
    {
        Task<IEnumerable<Iterations>> GetIterations(int AreaId);
        Task<int> GetIterationId(string iterationName);
        Task<string> GetIterationName(int id);
    }
}
