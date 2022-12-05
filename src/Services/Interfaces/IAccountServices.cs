using Models;

namespace Services.Interfaces
{
    public interface IAccountServices
    {
        Task<UserToken> LoginAsync(UserDto userDto);

        Task CreateAsync(UserDto userDto);

        Task DeleteAsync(UserDto userDto);

        Task UpdateAsync(UserDto userDto);
    }
}
