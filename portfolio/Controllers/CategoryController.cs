using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IService<Category> _categoryService;
        public CategoryController(IService<Category> categoryService) 
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryService.GetAll();
            View(categories);
            return View();
        }
    }
}
