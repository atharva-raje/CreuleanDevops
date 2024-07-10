using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class WorkItemLinkService :IWorkItemLinkService
    {
        private readonly IMapper _mapper;
        private readonly  IWorkItemLinkRepository _workItemsLinkRespository;

        public WorkItemLinkService(IWorkItemLinkRepository workItemsLinkRespository, IMapper mapper)
        {
            _mapper = mapper;
            _workItemsLinkRespository = workItemsLinkRespository;
        }

        public async Task<int> AddWorkItemLinkAsync(string sourceWorkItemId, string targetWorkItemId, string linkType)
        {
            var result = await GetWorkItemLinksAsync(sourceWorkItemId);
            foreach (var item in result)
            {
                if (item.TargetWorkItemId == targetWorkItemId && item.LinkType == linkType)
                {
                    return 0;
                }
            }
            var workItemLink = new WorkitemLink
            {
                SourceWorkItemId = sourceWorkItemId,
                TargetWorkItemId = targetWorkItemId,
                LinkType = linkType
            };
            await _workItemsLinkRespository.AddWorkItemLinkAsync(workItemLink);
            return 1;
        }

        public async Task<bool> DeleteWorkItemLinkAsync(string LinkId)
        {
            return await _workItemsLinkRespository.DeleteAllSourceWorkItemLinkAsync(LinkId);
        }

        public async Task<List<WorkitemLink>> GetWorkItemLinksAsync(string workItemId)
        {
            return await _workItemsLinkRespository.GetWorkItemLinksAsync(workItemId);
        }
    }
}
