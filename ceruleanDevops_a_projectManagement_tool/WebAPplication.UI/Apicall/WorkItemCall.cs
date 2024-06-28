using AutoMapper.Execution;
using Azure.Core;
using BusinessLOgic.Models;
using DAL.Entites;
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
        private readonly HttpClient _httpClient;
        public WorkItemCall(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddWorkItem(UIWorkItem uiWorkItem)
        {
            var sid = await _httpClient.GetFromJsonAsync<int>($"api/status/name/{uiWorkItem.status}");
            WorkItemModel newWorkItem = new WorkItemModel
            {
                Name = uiWorkItem.name,
                Description = uiWorkItem.description,
                iteration = uiWorkItem.iteration,
                area = uiWorkItem.area,
                Type = uiWorkItem.type,
                startDate = uiWorkItem.startdate,
                endDate = uiWorkItem.endate,
                priority = uiWorkItem.priority,
                statusId = sid,
                user = uiWorkItem.user
            };
            return await _httpClient.PostAsJsonAsync("api", newWorkItem);

        }

        public async Task<bool> deleteWorkItem(int id)
        {
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

        public async Task<IEnumerable<AreaWithoutId>> GetAreas()
        {
            var result = await _httpClient.GetFromJsonAsync<AreaWithoutId[]>("api/areas");
            return result;
        }

        public async Task<IEnumerable<IterationWIthoutId>> Getiterations(string areaname)
        {
            var id = await _httpClient.GetFromJsonAsync<int>($"api/areas/{areaname}");
            var result = await _httpClient.GetFromJsonAsync<IterationWIthoutId[]>($"api/iterations/{id}");
            return result;
        }

        public async Task<string> GetStatus(int statusId)
        {
            var result = await _httpClient.GetStringAsync($"api/status/id/{statusId}");
            return result;
        }

        public async Task<IEnumerable<StatusModelWithoutId>> GetStatusModels()
        {
            return await _httpClient.GetFromJsonAsync<StatusModelWithoutId[]>("api/status");
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<UserModel[]>("api/users/getall");
        }

        public async Task<IEnumerable<WorkItemModel>> GetWorkItems()
        {

            var result = await _httpClient.GetFromJsonAsync<WorkItemModel[]>("api/getall");
            Console.WriteLine(result);
            return result;

        }
        

    }
}
