using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface ITypeRepository
    {
       Task<IEnumerable<Types>> GetTypesAsync();
        Task<Types> GetTypeIdAsync(string TypeName);
        Task<Types> GetTypeName(int  TypeId);


    }
}
