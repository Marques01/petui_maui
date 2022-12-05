using Models;

namespace Services.Interfaces
{
    public interface IProductServices
    {
        Task<HttpResponseMessage> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<Product> GetByIdAsync(int id);

        Task<Product> GetByNameAsync(string name);

        Task<IEnumerable<Product>> GetProductsByPrice(decimal price);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task UploadImage(MultipartFormDataContent content);
    }
}
