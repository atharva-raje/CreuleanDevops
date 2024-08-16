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
        Task<bool> AddWorkItemLinkAsync(string sourceWorkItemId, string targetWorkItemId, int linkType);
        Task<List<WorkitemLink>> GetWorkItemLinksAsync(string workItemId);
        Task<bool> DeleteWorkItemLinkAsync(string LinkId);
    }
}
