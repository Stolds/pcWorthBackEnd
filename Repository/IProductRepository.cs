
using PcWorth.Models;

namespace PcWorth.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SearchProducts();
        Task<Product> SearchProduct(int id);
        void AddProduct(Product product);
        Task<bool> SaveChangesAsync();
    }
}