namespace WebAPplication.UI.IApicall
{
    public interface IUserApiCall
    {
        Task<String> GetUser(int id);
        Task<int> GetUserIdByName(string Name);
    }
}
