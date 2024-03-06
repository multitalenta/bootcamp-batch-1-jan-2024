using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRestoAPI.DatabaseContext;
using WebRestoAPI.Models;

namespace WebRestoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbWebRestoContext _context;

        public ProductController(DbWebRestoContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }


        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Product '{product.Nama}' Berhasil di Update.");
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            if (_context.Products == null)
            {
                return Problem("Entity set 'DbWebRestoContext.Products'  is null.");
            }

            var lastProductId = await _context.Products.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefaultAsync();
            var nextProductId = lastProductId + 1;

            product.Kode = $"MN3A{nextProductId:D3}";

            // Tambahkan produk ke dalam konteks
            _context.Products.Add(product);
            // Simpan perubahan ke dalam database
            await _context.SaveChangesAsync();

            // Kembalikan respons dengan produk yang baru saja dibuat
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok($"Product '{product.Nama}' berhasil dihapus.");
        }

        private bool ProductExists(long id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
