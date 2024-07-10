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

        public async Task<bool> LinkWorkItems(string sourceWorkItemId, string targetWorkItemId, string linkType)
        {
            var response = await _httpClient.PostAsJsonAsync("api/link", new { SourceWorkItemId = sourceWorkItemId, TargetWorkItemId = targetWorkItemId, LinkType = linkType });
            return response.IsSuccessStatusCode;
        }
    }
}
