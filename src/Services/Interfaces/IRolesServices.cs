using Models;

namespace Services.Interfaces
{
    public interface IRolesServices
    {
        Task<IEnumerable<ApplicationRoles>> GetAllRolesAsync();
    }
}
