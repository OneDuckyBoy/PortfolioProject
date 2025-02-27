﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IService<Project> _projectService;
        public readonly IService<Image> _imageService;
        public readonly IService<Category> _categoryService;
        public readonly IImageUploadService _ImageUploadService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public ProjectController(IService<Project> projectService, IService<Image> imageService, IService<Category> categoryService, UserManager<User> userManager, SignInManager<User> signInManager, IImageUploadService ImageUploadService)
        {
            _projectService = projectService;
            _imageService = imageService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _ImageUploadService = ImageUploadService;
        }
        public IActionResult Index(ProjectIndexFilterModelView? filter)
        {

            var likedByUser= _projectService.GetAll().AsQueryable().Include(p => p.LikedProjects).ThenInclude(lp => lp.User).Where(u => u.User == _userManager.GetUserAsync(User).Result);

            var query = _projectService.GetAll().AsQueryable();
            if (filter.CategoryId != null)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }
            if (filter.Title != null)
            {
                query = query.Where(p => p.Title.Contains(filter.Title));
            }
            if (filter.ShortDescription != null)
            {
                query = query.Where(p => p.ShortDescription.Contains(filter.ShortDescription));
            }

            var model = new ProjectIndexFilterModelView
            {
                CategoryId = filter.CategoryId,
                Title = filter.Title,
                ShortDescription = filter.ShortDescription,
                Categories = new SelectList(_categoryService.GetAll(), "Id", "Name"),
                Projects = query.Include(p => p.Category).Include(p=>p.Image).ToList(),
            };

            IEnumerable<Project> projects = _projectService.GetAll().ToList();
            IEnumerable<Image> images = _imageService.GetAll();
            IEnumerable<Category> categories = _categoryService.GetAll().ToList();
            foreach (var item in projects)
            {
                item.Image = images.FirstOrDefault(img => img.Id == item.ImageId);
                item.Category = categories.FirstOrDefault(cat => cat.Id == item.CategoryId);
            }

            ViewData["message from controller"] = "Hello from the backend : )";
            return View(model);
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
                image.Path = _ImageUploadService.UploadImageAsync(viewModel.Image).Result;
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
            var user = _userManager.FindByIdAsync((project.UserId + ""));
            if (user == null)
            {

                project.User = new User();
                project.User.Email = "unknow user";
            }
            project.User = user.Result;
            Console.WriteLine();
            return View(project);
        }
        [Route("Project/{id}")]
        public IActionResult Project1(int id)
        {
            Project project = _projectService.GetById(id);
            project.Category = _categoryService.GetById(project.CategoryId);
            project.Image = _imageService.GetById(project.ImageId);
            var user = _userManager.FindByIdAsync((project.UserId + ""));
            if (user == null)
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
