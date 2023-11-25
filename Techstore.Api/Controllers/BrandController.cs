using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techstore.Application.Brand.Queries;

namespace Techstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await Mediator.Send(new BrandGetAllQuery());

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var brand = await Mediator.Send(new BrandGetByIdQuery() { brand_id = id});

            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
    }
}
