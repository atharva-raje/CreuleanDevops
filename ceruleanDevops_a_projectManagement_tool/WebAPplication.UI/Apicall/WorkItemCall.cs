using AutoMapper;
using AutoMapper.Execution;
using Azure.Core;
using BusinessLOgic.Models;
using DAL.Entites;
using Microsoft.Identity.Client;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using WebAPplication.UI.IApicall;
using WebAPplication.UI.UiModels;
using static System.Net.WebRequestMethods;
using static WebAPplication.UI.Pages.ListofWorkItems;

namespace WebAPplication.UI.Apicall
{
    public class WorkItemCall : IWorkItemAPiCall
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public WorkItemCall(HttpClient httpClient,IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<HttpResponseMessage> AddWorkItem(UIWorkItem uiWorkItem)
        {
            
            return await _httpClient.PostAsJsonAsync("api", uiWorkItem);

        }

        public async Task<bool> deleteWorkItem(string id)
        {
            var dlink = await _httpClient.DeleteAsync($"api/link/delete/{id}");
            var result = await _httpClient.DeleteAsync($"api/delete/{id}");
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetAreaName(int id)
        {
            return await _httpClient.GetStringAsync($"api/areas/name/{id}");
        }

        public async Task<IEnumerable<AreaWithoutId>> GetAreas()
        {
            var result = await _httpClient.GetFromJsonAsync<AreaWithoutId[]>("api/areas");
            return result;
        }

        public async Task<string> GetIterationName(int id)
        {
            return await _httpClient.GetStringAsync ($"api/iterations/name/{id}");
        }

        public async Task<IEnumerable<IterationWIthoutId>> Getiterations(int areaId)
        {
            var result = await _httpClient.GetFromJsonAsync<IterationWIthoutId[]>($"api/iterations/{areaId}");
            return result;
        }

        public async Task<IEnumerable<PriorityModel>> GetPriorityModels()
        {
            var result = await _httpClient.GetFromJsonAsync<PriorityModel[]>($"api/priority/getall");
            return result;
        }

        public async Task<int> GetStatusId(string statusName)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/status/name/{statusName}");
            return result;
        }

        public async Task<IEnumerable<StatusModelWithoutId>> GetStatusModels(int TypeId)
        {
            return await _httpClient.GetFromJsonAsync<StatusModelWithoutId[]>($"api/status/{TypeId}");
        }

        public async Task<string> GetStatusName(int id)
        {
            return await _httpClient.GetStringAsync ($"api/status/id/{id}");
        }

        public async Task<IEnumerable<TypeModel>> GetTypeModels()
        {
            return await _httpClient.GetFromJsonAsync<TypeModel[]>("api/types/getall");
        }

        public async Task<string> GetTypeName(int id)
        {
            return await _httpClient.GetStringAsync ($"api/types/name/{id}");
        }

        public async Task<string> GetUserName(int id)
        {
            return await _httpClient.GetStringAsync ($"api/users/getById/{id}");
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<UserModel[]>("api/users/getall");
        }

        public async Task<UIWorkItem> GetWorkItemById(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<WorkItemModel>($"api/GetById/{id}");
            var assigneeName = await GetUserName(result.AssigneeId);
            var reporterName = await GetUserName(result.ReporterId);
            var model = _mapper.Map<UIWorkItem>(result);
            model.AssigneeName = assigneeName;
            model.ReporterName = reporterName;
            return model;
        }

        public async Task<int> GetWorkItemIdByKey(string key)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/key/{key}");
        }

        public async Task<IEnumerable<WorkItemModel>> GetWorkItems()
        {

            var result = await _httpClient.GetFromJsonAsync<WorkItemModel[]>("api/getall");
            Console.WriteLine(result);
            return result;

        }

        public async Task<IEnumerable<WorkItemModelWithString>> GetWorkItemsWithName()
        {
            var result = await _httpClient.GetFromJsonAsync<WorkItemModelWithString[]>($"api/getallWithName");
            return result;
        }

        public async Task<HttpResponseMessage> UpdateWorkItem(UIWorkItem uiWorkItem)
        {
            return await _httpClient.PutAsJsonAsync("api/update", uiWorkItem);
        }

         
    }
}
