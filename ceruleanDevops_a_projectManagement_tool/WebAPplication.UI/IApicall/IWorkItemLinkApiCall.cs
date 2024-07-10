namespace WebAPplication.UI.IApicall
{
    public interface IWorkItemLinkApiCall
    {
        Task<bool> LinkWorkItems(string sourceWorkItemId, string targetWorkItemId, string linkType);
        Task<HttpResponseMessage> DeleteLinks(string sourceId);
    }
}
