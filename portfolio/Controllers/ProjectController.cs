using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IService<Project> _projectService;
        public readonly IService<Image> _imageService;
        public readonly IService<Category> _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public ProjectController(IService<Project> projectService, IService<Image> imageService, IService<Category> categoryService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _projectService = projectService;
            _imageService = imageService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> projects = _projectService.GetAll().ToList();
            IEnumerable<Image> images = _imageService.GetAll();
            IEnumerable<Category> categories = _categoryService.GetAll().ToList();
            foreach (var item in projects)
            {
                item.Image = images.ToArray()[item.ImageId - 1];// [item.ImageId];
                item.Category = categories.ToArray()[item.CategoryId - 1];
            }
            return View(projects);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            var viewModel = new ProjectCreateViewModel
            {
                Categories = categories
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var user =  _userManager.GetUserAsync(User);
                if (user.Result == null)
                {
                    return Unauthorized();
                }
                var project = new Project
                {
                    Title = viewModel.Title,
                    ShortDescription = viewModel.ShortDescription,
                    Description = viewModel.Description,
                    CategoryId = viewModel.CategoryId
                };
                Image image = new Image();
                image.Path = viewModel.Path;

                project.Image = _imageService.Add(image);
                project.Category = _categoryService.GetById(project.CategoryId);
                project.Category = _categoryService.GetById(project.CategoryId);
                project.User = user.Result;
                _projectService.Add(project);
                return RedirectToAction("Index");
            }
            viewModel.Categories = _categoryService.GetAll();
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Project project = _projectService.GetById(id);
            project.Category = _categoryService.GetById(project.CategoryId);
            project.Image = _imageService.GetById(project.ImageId);
            var user= _userManager.FindByIdAsync((project.UserId+""));
            if (user==null)
            {

                project.User = new User();
                project.User.Email = "unknow user";
            }
            project.User = user.Result;
            Console.WriteLine();
            return View(project);
        }

        public IActionResult Edit(int id)
        {
            var categories = _categoryService.GetAll().ToList();

            Project project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Category = _categoryService.GetById(project.CategoryId);
            project.Image = _imageService.GetById(project.ImageId);
            var user = _userManager.FindByIdAsync((project.UserId + ""));
            if (user == null)
            {

                project.User = new User();
                project.User.Email = "unknow user";
            }
            project.User = user.Result;

            var viewModel = new ProjectEditViewModel
            {
                Id = project.Id,
                Title = project.Title,
                ShortDescription = project.ShortDescription,
                Description = project.Description,
                CategoryId = project.CategoryId,
                UserId = project.UserId,
                UserEmail = project.User.Email,
                ImageId = project.ImageId,
                ImagePath = project.Image.Path,
                
            };
            viewModel.Categories = categories;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProjectEditViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var project = _projectService.GetById(viewModel.Id);
                if (project == null)
                {
                    return NotFound();
                }

                project.Title = viewModel.Title;
                project.ShortDescription = viewModel.ShortDescription;
                project.Description = viewModel.Description;
                project.CategoryId = viewModel.CategoryId;
                project.ImageId = viewModel.ImageId ?? project.ImageId;

                _projectService.Update(project);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var project = _projectService.GetById(id);

            return View(project);
        }

        [HttpPost]
        public IActionResult Delete(Role role)
        {
            _projectService.Delete(role.Id);
            return RedirectToAction("Index");
        }
    }
}
