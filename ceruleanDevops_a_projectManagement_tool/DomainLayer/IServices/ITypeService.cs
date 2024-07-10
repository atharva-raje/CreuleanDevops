using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface ITypeService
    {
        Task<int> GetTypeId(string type);
        Task<IEnumerable<Types>> GetTypes();
        Task<string> GetTypeName(int  typeid);

    }
}
