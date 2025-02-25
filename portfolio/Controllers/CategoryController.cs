using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IService<Category> _categoryService;
        public readonly IService<Image> _imageService;
        public readonly IImageUploadService _ImageUploadService;
        private readonly IService<Project> _projectService;
        public CategoryController(IService<Category> categoryService, IService<Image> imageService, IImageUploadService imageUploadService, IService<Project> projectService)
        {
            _categoryService = categoryService;
            _imageService = imageService;
            _ImageUploadService = imageUploadService;
            _projectService = projectService;
        }
        public IActionResult Index()
        {
            var images = _imageService.GetAll().ToDictionary(img => img.Id);
            var categories = _categoryService.GetAll().ToList();

            foreach (var category in categories)
            {
                if (images.TryGetValue(category.ImageId, out var image))
                {
                    category.Image = image;
                }
            }

            return View(categories);
        }
        [Route("Category/All")]
        public IActionResult All()
        {
            var images = _imageService.GetAll().ToDictionary(img => img.Id);
            var categories = _categoryService.GetAll().ToList();

            foreach (var category in categories)
            {
                if (images.TryGetValue(category.ImageId, out var image))
                {
                    category.Image = image;
                }
            }

            return View(categories);
        }

        //[Route("Category/{id}")]
        //public IActionResult ProjectsInCategory(int id)
        //{
        //    var category = _categoryService.GetById(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    category.Projects = _projectService.GetAll()
        //        .Where(p => p.CategoryId == id).AsQueryable()
        //        .Include(p => p.Image)
        //        .Include(p => p.Comments)
        //        .ToList();

        //    if (category.Projects == null)
        //    {
        //        category.Projects = new List<Project>();
        //    }

        //    category.Image = _imageService.GetById(category.ImageId);
        //    if (category.Image == null)
        //    {
        //        category.Image = new Image { Path = "default-image-path.jpg" }; // Provide a default image path
        //    }

        //    return View(category);
        //}
        [Route("Category/{id}")]

        public IActionResult ProjectsInCategory(int id)
        {
            var category = _categoryService.GetById(id);
            category.Projects = _projectService.GetAll().AsQueryable()
         .Where(p => p.CategoryId == id)
         .Include(p => p.Image)
         .Include(p => p.Comments)
         .ToList();

            category.Image = _imageService.GetById(category.ImageId);

            return View(category);
        }
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);
            category.Image =_imageService.GetById(category.Id);
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            //if (ModelState.IsValid)
            //{

            //   category.Image= _imageService.Add(category.Image);
            //    _categoryService.Add(category);
            //    return RedirectToAction("Index");
            //}
            //return View(category);
            if (ModelState.IsValid)
            {
                // Handle the file upload using the imageUploadService
                if (model.Image != null && model.Image.Length > 0)
                {



                    var imageUrl = _ImageUploadService.UploadImageAsync(model.Image).Result;


                    var image = new Image
                    {
                        Path = imageUrl
                    };

                    image = _imageService.Add(image);
                    // Save the category details to the database

                    var category = new Category
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Image = image,
                        ImageId = image.Id
                    };
                    _categoryService.Add(category);

                    return RedirectToAction("Index");
                }
            }



            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var category =  _categoryService.GetById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryService.Delete(category.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            category.Image = _imageService.GetById(category.ImageId);
            return View(category);
        }

        [HttpPost]

        public IActionResult Edit( int id,Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            

            if (ModelState.IsValid)
            {
                Category oldCategory = _categoryService.GetById(category.Id);
                Image image= _imageService.GetById(oldCategory.ImageId);
                _categoryService.Detach(oldCategory);
                image.Path = category.Image.Path;
                category.Image = image;
                _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);


        }

        private bool CategoryExists(int id)
        {
            return _categoryService.EntityExists(id);
        }
    }
}
