using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ImageController : Controller
    {

        public readonly IService<Image> _imageService;
        public readonly IImageUploadService _imageUploadService;

        public ImageController(IService<Image> imageService, IImageUploadService imageUploadService)
        {
            _imageService = imageService;
            _imageUploadService = imageUploadService;
        }
        public IActionResult Index()
        {
            IEnumerable<Image> images = _imageService.GetAll();

            return View(images);
        }
        public IActionResult Details(int Id)
        {
            var image = _imageService.GetById(Id);
            return View(image);
        }
        public IActionResult Delete(int Id)
        {

            var image = _imageService.GetById(Id);

            return View(image);
        }
        [HttpPost]
        public IActionResult Delete(Image image)
        {
            var imageExists = _imageService.EntityExists(image.Id);
            if (!imageExists)
            {
                return NotFound();
            }
            image = _imageService.GetById(image.Id  );
            // Extract the public ID from the image URL
            var publicId = image.Path.Split('/').Last().Split('.').First();
            _imageUploadService.DeleteImageAsync(publicId);
            _imageService.Delete(image.Id);

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int Id)
        {
            var image = _imageService.GetById(Id);
            if (image == null)
            {
                return NotFound();
            }

            var model = new EditImageModel
            {
                Id = image.Id,
                ImageUrl = image.Path
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditImageModel model)
        {
            if (ModelState.IsValid)
            {
                var image = _imageService.GetById(model.Id);
                if (image == null)
                {
                    return NotFound();
                }

                image.Path = model.ImageUrl;
                _imageService.Update(image);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(CreateImageModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var imageUrl =  _imageUploadService.UploadImageAsync(model.ImageFile).Result;

                    var image = new Image
                    {
                        Path = imageUrl
                    };

                    _imageService.Add(image);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Please select an image file to upload.");
            }
            return View(model);
        }
    }
}
