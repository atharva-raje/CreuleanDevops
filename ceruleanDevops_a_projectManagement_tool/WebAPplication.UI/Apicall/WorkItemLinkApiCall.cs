using AutoMapper;
using Blazorise;
using BusinessLOgic.Models;
using System.Net.Http;
using System.Net.Http.Json;
using WebAPplication.UI.IApicall;
using WebAPplication.UI.Pages;

namespace WebAPplication.UI.Apicall
{
    public class WorkItemLinkApiCall : IWorkItemLinkApiCall

    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public WorkItemLinkApiCall(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<HttpResponseMessage>  DeleteLinks(string sourceId)
        {
            var dlink = await _httpClient.DeleteAsync($"api/link/delete/{sourceId}");
            return dlink;
        }

        public async Task<List<WorkItemLinkModel>> GetLinksForWorkItem(string sourceId)
        {
            var result = await _httpClient.GetFromJsonAsync<WorkItemLinkModel[]>($"api/GetLinksForWorkItem/{sourceId}");
            return result.ToList();
        }

        public async Task<bool> LinkWorkItems(string sourceWorkItemId, string targetWorkItemId, int linkType)
        {
            var response = await _httpClient.PostAsJsonAsync("api/LinkWorkItems", new { SourceWorkItemId = sourceWorkItemId, TargetWorkItemId = targetWorkItemId, LinkType = linkType });
            return response.IsSuccessStatusCode;
        }
    }
}
