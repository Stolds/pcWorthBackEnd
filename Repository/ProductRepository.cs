using Microsoft.EntityFrameworkCore;
using PcWorth.Data;
using PcWorth.Models;

namespace PcWorth.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            this._context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Product> SearchProduct(int id)
        {
            return await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> SearchProducts()
        {
            return await _context.Product.ToListAsync();
        }
    }
}