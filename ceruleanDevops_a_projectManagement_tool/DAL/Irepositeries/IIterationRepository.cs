using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IIterationRepository
    {
        Task<IEnumerable<Iterations>> GetIterations(int AreaId);
        Task<Iterations> GetIterationsIdAsync(string IterationName);
        Task<Iterations> GetIterationsNameAsync(int iterationId);

    }
}
