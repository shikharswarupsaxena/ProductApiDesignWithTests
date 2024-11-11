using Carl_Zeiss_Assignment.Data;
using Carl_Zeiss_Assignment.Models.Entities;
using Carl_Zeiss_Assignment.ExtensionClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carl_Zeiss_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            product.ProductID = _context.GenerateUniqueProductID();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProdutcs()
        {
            return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

         
            return Product;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            var prod = await _context.Products.FindAsync(id);
            if(prod == null)
            {
                return BadRequest("Product ID not found");

            }


            prod.Name = product.Name;
            prod.Description = product.Description;
           
            prod.StockAvailable = product.StockAvailable;
            prod.Price = product.Price;
          

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("decrement-stock/{id}/{quantity}")]
        public async Task<IActionResult> DecrementStock(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || product.StockAvailable < quantity) return BadRequest("Insufficient stock");

            product.StockAvailable -= quantity;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public async Task<IActionResult> AddToStock(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.StockAvailable += quantity;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
