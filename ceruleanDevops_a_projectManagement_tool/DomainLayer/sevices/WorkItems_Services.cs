using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class WorkItems_Services : IWorkItemServices
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemsRespository _workItemsRespository;

        public WorkItems_Services(IWorkItemsRespository workItemsRespository,IMapper mapper)
        {
            _mapper = mapper;
            _workItemsRespository = workItemsRespository;
        }

        public async Task<WorkItem> AddWorkItemsService(WorkItemModel workItemModel)
        {
            WorkItem newWorkItem = new WorkItem
            {
                 Name = workItemModel.Name,
                 Description = workItemModel.Description,
                 iteration = workItemModel.iteration,
                 area = workItemModel.area,
                 Type = workItemModel.Type,
                 statusId = workItemModel.statusId,
                 startDate = workItemModel.startDate,
                 endDate = workItemModel.endDate,
                 priority = workItemModel.priority,
                 user = workItemModel.user

            };
            var result = await _workItemsRespository.AddWorkitem(newWorkItem);
            return result;    
        }  

        public async Task<int> DeleteWorkItemsService(int WorkItemId)
        {
            return await _workItemsRespository.DeleteWorkItem(WorkItemId);
        }
        public async Task<IEnumerable<WorkItem>> GetWorkItemsService()
        {
            var result = await _workItemsRespository.GetWorkitems();
            return result;
             
        }

        public async Task<WorkItem> UpdateWorkItemsService(int id, WorkItemModel workItemModel)
        {

            WorkItem newWorkItem = new WorkItem
            {
                Name = workItemModel.Name,
                Description = workItemModel.Description,
                iteration = workItemModel.iteration,
                area = workItemModel.area,
                Type = workItemModel.Type,
                statusId = workItemModel.statusId,
                startDate = workItemModel.startDate,
                endDate = workItemModel.endDate,
                priority = workItemModel.priority

            };
            var result = await _workItemsRespository.UpdateWorkitem(id,newWorkItem);
            return result;
        }
    }
}
