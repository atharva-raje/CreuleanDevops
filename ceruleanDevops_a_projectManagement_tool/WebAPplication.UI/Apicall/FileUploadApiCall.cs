using AutoMapper;
using Blazorise;
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

        public async Task<bool> DeleteFile(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/files/delete/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<FileModel> GetFileById(int id)
        {
            return await _httpClient.GetFromJsonAsync<FileModel>($"getallByFileId/{id}");

        }

        public async Task<IEnumerable<FileModelWithoutData>> GetFilesForWorkItem(string id)
        {
            return await _httpClient.GetFromJsonAsync<FileModelWithoutData[]>($"api/files/getallById/{id}");
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
