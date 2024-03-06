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
    public class CartDetailController : ControllerBase
    {
        private readonly DbWebRestoContext _context;

        public CartDetailController(DbWebRestoContext context)
        {
            _context = context;
        }

        // GET: api/CartDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetails()
        {
            if (_context.CartDetails == null)
            {
                return NotFound();
            }
            try
            {
                var cartdetails = _context.CartDetails
                    .Include(p => p.Cart)
                    .Include(p => p.Product)
                    .ToList();
                return await _context.CartDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        // GET: api/CartDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetail(long id)
        {
          if (_context.CartDetails == null)
          {
              return NotFound();
          }
            var cartDetail = await _context.CartDetails.FindAsync(id);

            if (cartDetail == null)
            {
                return NotFound();
            }

            return cartDetail;
        }

        // PUT: api/CartDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(long id, CartDetail cartDetail)
        {
            if (id != cartDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InputCartDetail>> PostCartDetail(InputCartDetail InputCartDetail)
        {
            try
            {
                // Cari buku dan user berdasarkan Id_Buku dan Id_User
                var product = await _context.Products.FindAsync(InputCartDetail.Product_Id);


                if (product != null)
                {
                    decimal totalHarga = product.Harga * InputCartDetail.Qty;

                    var cartdetail = new CartDetail();
                    cartdetail.Product_Id = InputCartDetail.Product_Id;
                    cartdetail.Qty = InputCartDetail.Qty;
                    cartdetail.TotalHarga = totalHarga;
                    cartdetail.Catatan = InputCartDetail.Catatan;

                    cartdetail.Product = product;
                    // Tambahkan peminjaman ke DbContext
                    _context.CartDetails.Add(cartdetail);

                    // Simpan perubahan ke database
                    await _context.SaveChangesAsync();

                    // Kembalikan respons sukses
                    return Ok(cartdetail);
                }
                else
                {
                    // Kembalikan respons error jika buku atau user tidak ditemukan
                    return BadRequest("Cart atau Product tidak valid.");
                }
            }
            catch (Exception ex)
            {
                // Kembalikan respons error jika terjadi kesalahan
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/CartDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartDetail(long id)
        {
            if (_context.CartDetails == null)
            {
                return NotFound();
            }
            var cartDetail = await _context.CartDetails.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            _context.CartDetails.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartDetailExists(long id)
        {
            return (_context.CartDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
