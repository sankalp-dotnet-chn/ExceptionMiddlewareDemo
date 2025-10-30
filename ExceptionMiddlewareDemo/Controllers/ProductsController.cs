using Microsoft.AspNetCore.Mvc;
using ExceptionMiddlewareAdvanced.Exceptions;

namespace ExceptionMiddlewareAdvanced.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                throw new ValidationException(new[] { "Product ID must be greater than zero.", "ERROR 2"});

            if (id == 5)
                throw new UnauthorizedException("You are not authorized to view this product.");

            if (id > 10)
                throw new NotFoundException($"Product with ID {id} not found.");

            return Ok(new { Id = id, Name = "Product " + id });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException(new[] { "Product name is required." });

            return CreatedAtAction(nameof(GetProduct), new { id = 1 }, product);
        }
    }

    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
