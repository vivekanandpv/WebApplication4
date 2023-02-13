using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async  Task<ActionResult<IEnumerable<ProductViewModel>>> GetAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductViewModel>> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> CreateAsync(ProductCreateViewModel product)
        {
            return Ok(await _service.CreateAsync(product));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductViewModel>> UpdateAsync(int id, ProductUpdateViewModel product)
        {
            return Ok(await _service.UpdateAsync(id, product));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
