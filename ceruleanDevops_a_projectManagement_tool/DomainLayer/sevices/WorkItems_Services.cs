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
            var newWorkItem = _mapper.Map<WorkItem>(workItemModel);
            var result = await _workItemsRespository.AddWorkitem(newWorkItem);
            return result;    
        }  

        public Task<WorkItem> DeleteWorkItemsService()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsService()
        {
            return await _workItemsRespository.GetWorkitems();
        }

        public Task<WorkItem> UpdateWorkItemsService()
        {
            throw new NotImplementedException();
        }
    }
}
