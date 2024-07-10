using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IWorkItemLinkService
    {
        Task<int> AddWorkItemLinkAsync(string sourceWorkItemId, string targetWorkItemId, string linkType);
        Task<List<WorkitemLink>> GetWorkItemLinksAsync(string workItemId);
        Task<bool> DeleteWorkItemLinkAsync(string LinkId);
    }
}
