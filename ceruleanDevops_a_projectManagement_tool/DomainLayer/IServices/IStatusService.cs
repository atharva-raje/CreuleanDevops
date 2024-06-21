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
    }
}
