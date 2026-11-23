using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;         

        public ProductsController(IProductService productService)
        {
            _productService = productService;            
        }
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var products = await _productService.Get();
            return products;
        }
    }
}
