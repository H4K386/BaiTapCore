using _0306241284_NguyenKhanhHuy.Data;
using _0306241284_NguyenKhanhHuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            Console.WriteLine($">>> DU LIEU NHAN DUOC: Name='{model.Name}', Desc='{model.Description}'");
            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> BI LOI VALIDATION:");
                // Dữ liệu nhập sai -> Trả lại View kèm model và lỗi để người dùng sửa
                return RedirectToAction(nameof(Index));
            }
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description ?? String.Empty
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _context.Categories.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category); // Gọi file Edit.cshtml
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var category = await _context.Categories.FindAsync(model.Id);
            if (category == null) return NotFound();
            
            category.Name = model.Name;
            category.Description = model.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa danh mục thành công!";
            }
            catch (DbUpdateException) {
                TempData["ErrorMessage"] = "Không thể xóa danh mục này do đang có ràng buộc dữ liệu với Sản phẩm!";

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
