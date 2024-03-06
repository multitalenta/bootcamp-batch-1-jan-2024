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
    public class OrderDetailController : ControllerBase
    {
        private readonly DbWebRestoContext _context;

        public OrderDetailController(DbWebRestoContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            try
            {
                var cartdetails = _context.OrderDetails
                    .Include(p => p.Order)
                    .Include(p => p.Product)
                    .ToList();
                return await _context.OrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(long id)
        {
          if (_context.OrderDetails == null)
          {
              return NotFound();
          }
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/OrderDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(long id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InputOrderDetail>> PostOrderDetail(InputOrderDetail InputOrderDetail)
        {
            try
            {

                var order = await _context.Orders.FindAsync(InputOrderDetail.Order_Id);
                var product = await _context.Products.FindAsync(InputOrderDetail.Product_Id);


                if ( product != null)
                {
                    decimal totalHarga = product.Harga * InputOrderDetail.Qty;

                    var orderdetail = new OrderDetail();
                    orderdetail.Order_Id = InputOrderDetail.Order_Id;
                    orderdetail.Product_Id = InputOrderDetail.Product_Id;
                    orderdetail.Qty = InputOrderDetail.Qty;
                    orderdetail.TotalHarga = totalHarga;
                    orderdetail.Catatan = InputOrderDetail.Catatan;
                    
                    orderdetail.Product = product;
                    // Tambahkan peminjaman ke DbContext
                    _context.OrderDetails.Add(orderdetail);

                    // Simpan perubahan ke database
                    await _context.SaveChangesAsync();

                    // Kembalikan respons sukses
                    return Ok(orderdetail);
                }
                else
                {
                    // Kembalikan respons error jika buku atau user tidak ditemukan
                    return BadRequest("Order atau Product tidak valid.");
                }
            }
            catch (Exception ex)
            {
                // Kembalikan respons error jika terjadi kesalahan
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(long id)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(long id)
        {
            return (_context.OrderDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
