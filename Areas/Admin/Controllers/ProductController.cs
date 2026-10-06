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

        

        public async Task<IActionResult> Index()
        {
            var list = await _context.Products.ToListAsync();
            return View(list);
        }
    }
}
