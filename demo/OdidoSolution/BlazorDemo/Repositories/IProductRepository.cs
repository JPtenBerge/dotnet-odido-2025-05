using EntityFrameworkDemo;

namespace BlazorDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAll();
    }
}