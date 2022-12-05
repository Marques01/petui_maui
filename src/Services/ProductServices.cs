using Microsoft.JSInterop;
using Models;
using Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Utils;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private HttpClient _client;

        private IJSRuntime _js;

        public ProductServices(HttpClient client, IJSRuntime js)
        {
            _client = client;

            _js = js;
        }

        public async Task<HttpResponseMessage> CreateAsync(Product product)
        {
            try
            {
                await SetTokenHeaderAuthorization();

                var response = await _client.PostAsJsonAsync("api/product", product);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new Exception(ex.Message);
            }
        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task SetTokenHeaderAuthorization()
        {
            var token = await _js.GetFromLocalStorage(TokenAuthenticationProvider.TokenKey);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        public async Task UploadImage(MultipartFormDataContent content)
        {
            await SetTokenHeaderAuthorization();

            await _client.PostAsync("api/product/image", content);
        }
    }
}
