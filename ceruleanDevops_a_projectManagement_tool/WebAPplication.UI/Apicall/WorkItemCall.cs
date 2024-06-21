using BusinessLOgic.Models;
using DAL.Entites;
using System.Net.Http.Json;
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
            var sid = await _httpClient.GetFromJsonAsync<int>($"api/status/{uiWorkItem.status}");
            WorkItemModel newWorkItem = new WorkItemModel
            {
                Name = uiWorkItem.name,
                Description = uiWorkItem.description,
                iteration = uiWorkItem.iteration,
                area = uiWorkItem.area,
                Type = uiWorkItem.type,
                statusId = sid
            };
            return await _httpClient.PostAsJsonAsync("api", newWorkItem);
            
        }

        public async Task<IEnumerable<WorkItemModel>> GetWorkItems()
        {

            var result = await _httpClient.GetFromJsonAsync<WorkItemModel[]>("api/getall");
            Console.WriteLine(result);
            return result;

        }
    }
}
