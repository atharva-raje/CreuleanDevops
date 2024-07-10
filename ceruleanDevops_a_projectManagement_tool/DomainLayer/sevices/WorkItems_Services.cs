using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebAPplication.UI.UiModels;

namespace BusinessLOgic.sevices
{
    public class WorkItems_Services : IWorkItemServices
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemsRespository _workItemsRespository;
        private readonly IAreaService _areaService;
        private readonly IIterationService iterationService;
        private readonly ITypeService _typeService;
        private readonly IStatusService _statusService;
        private readonly IPriorityService priorityService;
        private readonly IUserSerivce userSerivce;
        public WorkItems_Services(IWorkItemsRespository workItemsRespository,IMapper mapper, IAreaService areaService, IIterationService iterationService, ITypeService typeRepository,
                                  IStatusService statusService,IPriorityService priorityService,IUserSerivce userSerivce)
        {
            _mapper = mapper;
            _workItemsRespository = workItemsRespository;
            _areaService = areaService;
            this.iterationService = iterationService;
            _typeService = typeRepository;
            _statusService = statusService;
            this.priorityService = priorityService;
            this.userSerivce = userSerivce;
        }

        public async Task<WorkItem> AddWorkItemsService(UIWorkItem workItemModel)
        {


            WorkItem newWorkItem = new WorkItem
            {
                WorkItemId = await GenerateUniqueKeyAsync(workItemModel),
                Name = workItemModel.Name,
                Description = workItemModel.Description,
                AreaId = workItemModel.AreaId,
                IterationId = (int)workItemModel.IterationId,
                TypeId = workItemModel.TypeId,
                StatusId = (int)workItemModel.StatusId,
                ActualStartDate = workItemModel.ActualStartDate,
                ActualEndDate = workItemModel.ActualEndDate,
                PriorityId = workItemModel.PriorityId,
                AssigneeId = await userSerivce.GetUserIdByName(workItemModel.AssigneeName),
                ReporterId = await userSerivce.GetUserIdByName(workItemModel.ReporterName),
                StoryPoints = workItemModel.StoryPoints
            };
            var result = await _workItemsRespository.AddWorkitemAsync(newWorkItem);
            return result;    
        }  

        public async Task<int> DeleteWorkItemsService(string WorkItemId)
        {
            return await _workItemsRespository.DeleteWorkItemAsync(WorkItemId);
        }

        public async Task<WorkItem> GetWorkItemById(string WorkItemId)
        {
            return await _workItemsRespository.GetWorkitemByIdAsync(WorkItemId);
        }

        public async Task<IEnumerable<WorkItem>> GetWorkItemsService()
        {
            var result = await _workItemsRespository.GetWorkitemsAsync();
            return result;
             
        }

        public async Task<WorkItem> UpdateWorkItemsService(UIWorkItem workItemModel)
        {

            WorkItem newWorkItem = new WorkItem
            {
                 
                WorkItemId = workItemModel.WorkItemId,
                Name = workItemModel.Name,
                Description = workItemModel.Description,
                AreaId = workItemModel.AreaId,
                IterationId =  (int)workItemModel.IterationId,
                TypeId =  workItemModel.TypeId,
                StatusId = (int)workItemModel.StatusId,
                ActualStartDate = workItemModel.ActualStartDate,
                ActualEndDate = workItemModel.ActualEndDate,
                PriorityId =  workItemModel.PriorityId,
                AssigneeId = await userSerivce.GetUserIdByName(workItemModel.AssigneeName),
                ReporterId = await userSerivce.GetUserIdByName(workItemModel.ReporterName),
                StoryPoints = workItemModel.StoryPoints,
                ExpectedStartDate = workItemModel.ExpectedStartDate,
                ExpectedEndDate = workItemModel.ExpectedEndDate
            };
            var result = await _workItemsRespository.UpdateWorkitemAsync(newWorkItem);
            return result;
        }
        public async Task<string> GenerateUniqueKeyAsync(UIWorkItem workItem)
        {
            var typeName = await _typeService.GetTypeName(workItem.TypeId);
            string prefix = typeName.Substring(0, 2).ToUpperInvariant(); 
            const int numberLength = 4;
            string uniqueKey;
             List<WorkItem> list = new List<WorkItem>();
            do
            {
                var list1 = await _workItemsRespository.GetWorkitemsAsync();
                list = list1.ToList();
                int maxNumber =  list
                    .Where(w => w.WorkItemId.StartsWith(prefix))
                    .Select(w => int.Parse(w.WorkItemId.Substring(2)))
                    .DefaultIfEmpty(0)
                    .Max();

                uniqueKey = $"{prefix}{(maxNumber + 1).ToString().PadLeft(numberLength, '0')}";
            } while (list.Any(w => w.WorkItemId == uniqueKey));

            return uniqueKey;
        }
    }
}
