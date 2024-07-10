using AutoMapper;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;
using System.Runtime.Serialization.Formatters;
using WebAPplication.UI.IApicall;
using static System.Net.WebRequestMethods;

namespace WebAPplication.UI.Apicall
{
    public class FileUploadApiCall : IFileUploadApiCall
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public FileUploadApiCall(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FileModel>> GetFilesForWorkItem(string id)
        {
            return await _httpClient.GetFromJsonAsync<FileModel[]>($"api/files/getallById/{id}");
        }

        public async Task<HttpResponseMessage> UploadFile(MultipartFormDataContent file)
        {
            try
            {
                var result =await _httpClient.PostAsync("api/files/upload",file); ;
                return result;
            }
            catch (Exception ex)
            {
                var errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"An error occurred while uploading the file: {ex.Message}")
                };
                return errorResponse;
            }
        }

    }
}
