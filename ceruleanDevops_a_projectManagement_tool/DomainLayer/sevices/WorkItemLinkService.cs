using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using SharedEnums;
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

        public async Task<bool> AddWorkItemLinkAsync(string sourceWorkItemId, string targetWorkItemId, int linkType)
        {
            var result = await GetWorkItemLinksAsync(sourceWorkItemId);
            foreach (var item in result)
            {
                if (item.TargetWorkItemId == targetWorkItemId && item.LinkType == linkType)
                {
                    return false;
                }
                else if (linkType == 1 && item.LinkType == 1)
                {
                    return false;
                }
                else if (item.TargetWorkItem == item.SourceWorkItem)
                {
                    return false;
                }
             }
            int newLinktype = 0;
            if (linkType == 1) {
                newLinktype = 2;
             }
            else if (linkType == 2)
            {
                newLinktype = 1;
            }
            else
            {
                newLinktype = linkType;
            }
            var workItemLink = new WorkitemLink
            {
                SourceWorkItemId = sourceWorkItemId,
                TargetWorkItemId = targetWorkItemId,
                 LinkType = linkType
            };
            await _workItemsLinkRespository.AddWorkItemLinkAsync(workItemLink);
            var workItemLink2 = new WorkitemLink
            {
                SourceWorkItemId = targetWorkItemId,
                TargetWorkItemId = sourceWorkItemId,
                LinkType = newLinktype
            };
            await _workItemsLinkRespository.AddWorkItemLinkAsync(workItemLink2);
            return true;
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
