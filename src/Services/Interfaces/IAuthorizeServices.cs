namespace Services.Interfaces
{
    public interface IAuthorizeServices
    {
        Task Login(string token);

        Task Logout();
    }
}
