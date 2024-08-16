using BusinessLOgic.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace WebAPplication.UI.IApicall
{
    public interface IFileUploadApiCall
    {
        Task<HttpResponseMessage> UploadFile(MultipartFormDataContent file);
        Task<IEnumerable<FileModelWithoutData>> GetFilesForWorkItem(string id);
        Task<FileModel> GetFileById(int id);
        Task<bool> DeleteFile(int id);
    }
}
