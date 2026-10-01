using _0306241284_NguyenKhanhHuy.Data;
using Microsoft.AspNetCore.Mvc;

namespace _0306241284_NguyenKhanhHuy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
