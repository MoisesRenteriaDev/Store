using Core.Entities;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController(StoreContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProduct(Guid id, Product product)
        {
            if (product.Id != id || !ProductExists(id))
                return BadRequest("Cannot update this product");

            context.Entry(product).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            context.Products.Remove(product);

            context.SaveChanges();

            return NoContent();
        }

        private bool ProductExists(Guid id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}