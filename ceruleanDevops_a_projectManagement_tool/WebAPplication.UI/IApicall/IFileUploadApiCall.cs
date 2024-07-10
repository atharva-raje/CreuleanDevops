using BusinessLOgic.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace WebAPplication.UI.IApicall
{
    public interface IFileUploadApiCall
    {
        Task<HttpResponseMessage> UploadFile(MultipartFormDataContent file);
        Task<IEnumerable<FileModel>> GetFilesForWorkItem(string id);
    }
}
