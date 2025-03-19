using System.Diagnostics;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<Image> _imageService;
        private readonly IService<Category> _categoryService;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(ILogger<HomeController> logger, IService<Image>imageService, IService<Category> categoryService)
        {
            _logger = logger;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            string  Me_image = _imageService.GetById(1008).Path;
            string programing_image = _imageService.GetById(1001).Path;
            ViewBag.Me_image = Me_image;
            ViewBag.programing_image = programing_image;

            var images = _imageService.GetAll().ToDictionary(img => img.Id);
            var categories = _categoryService.GetAll().ToList();

            foreach (var category in categories)
            {
                if (images.TryGetValue(category.ImageId, out var image))
                {
                    category.Image = image;
                }
            }
            categories.RemoveAt(0);
            ViewBag.categories = categories;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AboutMe")]
        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult StatusCode(int code)
        {
            switch (code)
            {
                case 404:
                    return View("404");
                case 500:
                    return View("500");
                default:
                    return View(new StatusCodeViewModel { StatusCode = code });
            }
        }
    }
}
