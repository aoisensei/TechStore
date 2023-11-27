using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techstore.Application.Brand.Commands;
using Techstore.Application.Brand.Queries;
using Techstore.Application.Category.Commands;
using Techstore.Application.Category.Queries;

namespace Techstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await Mediator.Send(new CategoryGetAllQuery());

            return Ok(categories);
        }

        [HttpGet("{category_id}")]
        public async Task<IActionResult> GetByIdAsync(string category_id)
        {
            var category = await Mediator.Send(new CategoryGetByIdQuery() { category_id = category_id });

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryCreateCommand command)
        {
            var createCategory = await Mediator.Send(command);

            return Ok(new
            {
                createCategory.category_id,
                createCategory.category_name
            });
        }

        [HttpPut("{category_id}")]
        public async Task<IActionResult> UpdateAsync(string category_id, CategoryUpdateCommand command)
        {
            if (!category_id.Equals(command.category_id))
            {
                return BadRequest("Không tìm thấy bản ghi!!!");
            }

            await Mediator.Send(command);

            return Ok("Sửa bản ghi thành công!!!");
        }

        [HttpDelete("{category_id}")]
        public async Task<IActionResult> DeleteAsync(string category_id)
        {
            var result = await Mediator.Send(new CategoryDeleteCommand { category_id = category_id });

            if (result == null)
            {
                return BadRequest("Không tìm thấy bản ghi!!!");
            }

            return Ok("Đã xóa bản ghi!!!");
        }
    }
}
