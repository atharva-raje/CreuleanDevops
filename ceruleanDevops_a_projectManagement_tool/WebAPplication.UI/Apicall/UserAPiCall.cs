using AutoMapper;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using WebAPplication.UI.IApicall;

namespace WebAPplication.UI.Apicall
{
    public class UserAPiCall : IUserApiCall
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public UserAPiCall(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<string> GetUser(int id)
        {
            return await _httpClient.GetStringAsync($"api/users/getById/{id}");
        }

        public async Task<int> GetUserIdByName(string Name)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/users/getByName/{Name}");
            return result;
        }
    }
}
