using Models;
using Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Services
{
    public class AccountServices : IAccountServices
    {
        private HttpClient _client;

        public AccountServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserToken> LoginAsync(UserDto userDto)
        {
            try
            {
                var userRequest = await _client.PostAsJsonAsync("api/account/login", userDto);

                var userResponse = await userRequest.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(userResponse))
                {
                    var user = JsonSerializer.Deserialize<UserToken>(userResponse);

                    if (user != null)
                        return user;
                }

                return new UserToken();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateAsync(UserDto userDto)
        {
            try
            {
                await _client.PostAsJsonAsync("api/Account", userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Task UpdateAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
