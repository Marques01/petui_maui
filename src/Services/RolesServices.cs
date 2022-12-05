using Microsoft.JSInterop;
using Models;
using Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Utils;

namespace Services
{
    public class RolesServices : IRolesServices
    {
        private HttpClient _client;

        private IJSRuntime _js;

        public RolesServices(HttpClient client, IJSRuntime js)
        {
            _client = client;

            _js = js;
        }

        public async Task<IEnumerable<ApplicationRoles>> GetAllRolesAsync()
        {
            try
            {
                await SetTokenHeaderAuthorization();

                var roles = await _client.GetFromJsonAsync<IEnumerable<ApplicationRoles>>("api/account/roles");

                if (roles != null)
                    return roles;

                return Enumerable.Empty<ApplicationRoles>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception(ex.Message);
            }
        }

        private async Task SetTokenHeaderAuthorization()
        {
            var token = await _js.GetFromLocalStorage(TokenAuthenticationProvider.TokenKey);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
}
