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
    public class TypeRepository : ITypeRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public TypeRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public async Task<Types> GetTypeIdAsync(string TypeName)
        {
            return await _workItemsDbContext.Types.FirstOrDefaultAsync(t => t.TypeName == TypeName);
        }

        public async Task<Types> GetTypeName(int TypeId)
        {
            return await _workItemsDbContext.Types.FirstOrDefaultAsync(t => t.TypeId == TypeId);
        }

        public async Task<IEnumerable<Types>> GetTypesAsync()
        {
            return await _workItemsDbContext.Types.ToListAsync();
        }
    }
}
