using PcWorth.Models;
using PcWorth.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PcWorth.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _repository.AddProduct(product);
            return await _repository.SaveChangesAsync()
             ?Ok("Product added sucessfully")
             : BadRequest("BadRequest, try again");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.SearchProducts();
            return products.Any()
                ? Ok(products)
                : NoContent();
        }
    }
}