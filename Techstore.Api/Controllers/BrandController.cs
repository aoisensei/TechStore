using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techstore.Application.Brand.Commands;
using Techstore.Application.Brand.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet("{brand_id}")]
        public async Task<IActionResult> GetByIdAsync(string brand_id)
        {
            var brand = await Mediator.Send(new BrandGetByIdQuery() { brand_id = brand_id });

            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BrandCreateCommand command)
        {
            var createBrand = await Mediator.Send(command);

            return Ok(new
            {
                createBrand.brand_id,
                createBrand.brand_name
            });
        }

        [HttpPut("{brand_id}")]
        public async Task<IActionResult> UpdateAsync(string brand_id, BrandUpdateCommand command)
        {
            if (!brand_id.Equals(command.brand_id))
            {
                return BadRequest("Không tìm thấy bản ghi!!!");
            }

            await Mediator.Send(command);

            return Ok("Sửa bản ghi thành công!!!");
        }

        [HttpDelete("{brand_id}")]
        public async Task<IActionResult> DeleteAsync(string brand_id)
        {
            var result = await Mediator.Send(new BrandDeleteCommand { brand_id = brand_id});

            if (result == null)
            {
                return BadRequest("Không tìm thấy bản ghi!!!");
            }

            return Ok("Đã xóa bản ghi!!!");
        }
    }
}
