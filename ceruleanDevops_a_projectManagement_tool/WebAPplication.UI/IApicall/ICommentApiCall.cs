using BusinessLOgic.Models;

namespace WebAPplication.UI.IApicall
{
    public interface ICommentApiCall
    {
        Task<HttpResponseMessage> AddComment(CommentModel comment);
        Task<IEnumerable<CommentModel>> GetComments(string workItemId);
    }
}
