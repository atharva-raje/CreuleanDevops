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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public WorkItems_Services(IWorkItemsRespository workItemsRespository, IMapper mapper, IAreaService areaService, IIterationService iterationService, ITypeService typeRepository,
                                  IStatusService statusService, IPriorityService priorityService, IUserSerivce userSerivce)
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
                ExpectedStartDate = workItemModel.ExpectedStartDate,
                ExpectedEndDate = workItemModel.ExpectedEndDate,
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
                IterationId = (int)workItemModel.IterationId,
                TypeId = workItemModel.TypeId,
                StatusId = (int)workItemModel.StatusId,
                ExpectedStartDate = workItemModel.ExpectedStartDate,
                ExpectedEndDate = workItemModel.ExpectedEndDate,
                PriorityId = workItemModel.PriorityId,
                AssigneeId = await userSerivce.GetUserIdByName(workItemModel.AssigneeName),
                ReporterId = await userSerivce.GetUserIdByName(workItemModel.ReporterName),
                StoryPoints = workItemModel.StoryPoints,
                ActualStartDate = workItemModel.ActualStartDate,
                ActualEndDate = workItemModel.ActualEndDate
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
                int maxNumber = list
                    .Where(w => w.WorkItemId.StartsWith(prefix))
                    .Select(w => int.Parse(w.WorkItemId.Substring(2)))
                    .DefaultIfEmpty(0)
                    .Max();

                uniqueKey = $"{prefix}{(maxNumber + 1).ToString().PadLeft(numberLength, '0')}";
            } while (list.Any(w => w.WorkItemId == uniqueKey));

            return uniqueKey;
        }

        public async Task<IEnumerable<WorkItemModelWithString>> GetWorkItemsWithNames()
        {
            var data = await _workItemsRespository.GetWorkitemsAsync();
            List<WorkItemModelWithString> displayData = new List<WorkItemModelWithString>();
            foreach (var item in data)
            {
                var element = new WorkItemModelWithString
                {
                    TypeId = await _typeService.GetTypeName(item.TypeId),
                    IterationId = await iterationService.GetIterationName(item.IterationId),
                    StatusId = await _statusService.GetStatusName(item.StatusId),
                    AreaId = await _areaService.GetAreaName(item.AreaId),
                    AssigneeName = await userSerivce.GetUser(item.AssigneeId),
                    ReporterName = await userSerivce.GetUser(item.ReporterId),
                    PriorityId = await priorityService.GetPriorityName(item.PriorityId),
                    StoryPoints = item.StoryPoints,
                    WorkItemId = item.WorkItemId,
                    Description = item.Description,
                    ActualEndDate = item.ActualEndDate,
                    ActualStartDate = item.ActualStartDate,
                    ExpectedStartDate = item.ExpectedStartDate,
                    ExpectedEndDate = item.ExpectedEndDate,
                    Name = item.Name
                };
                displayData.Add(element);
            }
            return displayData;
        }

        public async Task<WorkItem> UpdateWorkItemsServiceWithNames(WorkItemModelWithString workItemModel)
        {
            WorkItem newWorkItem = new WorkItem
            {

                WorkItemId = workItemModel.WorkItemId,
                Name = workItemModel.Name,
                Description = workItemModel.Description,
                AreaId = await _areaService.GetAreaId(workItemModel.AreaId),
                IterationId = await iterationService.GetIterationId(workItemModel.IterationId),
                TypeId = await _typeService.GetTypeId(workItemModel.AreaId),
                StatusId = await _statusService.GetStatusId(workItemModel.StatusId),
                ExpectedStartDate = workItemModel.ExpectedStartDate,
                ExpectedEndDate = workItemModel.ExpectedEndDate,
                PriorityId = await priorityService.GetPriorityId(workItemModel.PriorityId),
                AssigneeId = await userSerivce.GetUserIdByName(workItemModel.AssigneeName),
                ReporterId = await userSerivce.GetUserIdByName(workItemModel.ReporterName),
                StoryPoints = workItemModel.StoryPoints,
                ActualStartDate = workItemModel.ActualStartDate,
                ActualEndDate = workItemModel.ActualEndDate
            };
            var result = await _workItemsRespository.UpdateWorkitemAsync(newWorkItem);
            return result;
        }

       
    }
}
