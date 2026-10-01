using _0306241284_NguyenKhanhHuy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _0306241284_NguyenKhanhHuy.Models;
namespace _0306241284_NguyenKhanhHuy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product) {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
