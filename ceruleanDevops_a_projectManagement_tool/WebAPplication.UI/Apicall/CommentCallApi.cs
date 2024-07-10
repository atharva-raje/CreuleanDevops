using AutoMapper;
using BusinessLOgic.Models;
using System.Net.Http.Json;
using WebAPplication.UI.IApicall;

namespace WebAPplication.UI.Apicall
{
    public class CommentCallApi : ICommentApiCall
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public CommentCallApi(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<HttpResponseMessage> AddComment(CommentModel comment)
        {
            return await _httpClient.PostAsJsonAsync($"api/comments/add", comment);
        }

        public async Task<IEnumerable<CommentModel>> GetComments(string workitemId)
        {
            var result = await _httpClient.GetFromJsonAsync<CommentModel[]>($"api/comments/getall/{workitemId}");
            return result;
        }
    }
}
