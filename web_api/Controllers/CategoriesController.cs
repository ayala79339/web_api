using Entities;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
    public class CategoriesController : Controller
    {
        
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var list = await _service.Get();
            return list;
        }
    }
}
