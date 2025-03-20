using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IService<Project> _projectService;
        public readonly IService<Image> _imageService;
        public readonly IService<Category> _categoryService;
        public readonly IService<Comment> _commentCategory;
        public readonly IImageUploadService _ImageUploadService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public ProjectController(IService<Project> projectService, IService<Image> imageService, IService<Category> categoryService, UserManager<User> userManager, SignInManager<User> signInManager,  IImageUploadService ImageUploadService, IService<Comment> commentCategory)
        {
            _projectService = projectService;
            _imageService = imageService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _ImageUploadService = ImageUploadService;
            _commentCategory = commentCategory;
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
        [Route("Projects")]
        public IActionResult All(ProjectIndexFilterModelView? filter)
        {

            var likedByUser = _projectService.GetAll().AsQueryable().Include(p => p.LikedProjects).ThenInclude(lp => lp.User).Where(u => u.User == _userManager.GetUserAsync(User).Result);

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
                Projects = query.Include(p => p.Category).Include(p => p.Image).ToList(),
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
        [Route("Project/Create")]
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
        [Route("Project/Create")]
        public IActionResult Create(ProjectCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var user = _userManager.GetUserAsync(User);
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
        [Route("Project2/{id}")]
        public IActionResult Project2(int id)
        {
            //Project project = _projectService.GetById(id);
            //if (project==null)
            //{
            //    Console.WriteLine("???");
            //}
            User currentUser;

            if (User.Identity.IsAuthenticated)
            {
                // Потребителят е логнат
                currentUser = _userManager.GetUserAsync(User).Result;
                
            }
            else
            {
                int defaultUserId = 1006;
                currentUser = _userManager.FindByIdAsync(defaultUserId.ToString()).Result;
            }
            if (id == 0)
            {
                return BadRequest("Invalid project ID.");
            }

            Project project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound("Project not found.");
            }

            project.Category = _categoryService.GetById(project.CategoryId);
            project.Comments = _commentCategory.GetAll().AsQueryable().Include(c=>c.Image).Include(c=>c.LikedComments).Include(c=>c.User).Where(c => c.ProjectId == project.Id).ToList();
            project.Image = _imageService.GetById(project.ImageId);
            var user = _userManager.FindByIdAsync((project.UserId + "")).Result;
            Image userImage = _imageService.GetById(user.ProfilePictureId.Value);
            user.ProfilePicture = userImage;
            
            // todo
            project.User = user;
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool hasLiked = false;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                int count =project.Comments.Where(c => (c.UserId + "").Equals(currentUserId)).Count();
                hasLiked = count == 1;
            }


            Console.WriteLine();
            return View(project);
        }



        [Route("Project/{id}")]
        public IActionResult Project1(int id)
        {
            User currentUser;

            if (User.Identity.IsAuthenticated)
            {
                // Потребителят е логнат
                currentUser = _userManager.GetUserAsync(User).Result;
            }
            else
            {
                int defaultUserId = 1006;
                currentUser = _userManager.FindByIdAsync(defaultUserId.ToString()).Result;
                if (currentUser == null)
                {
                    return NotFound("Default user not found.");
                }
            }
            ViewBag.currentUser = currentUser;

            if (id == 0)
            {
                return BadRequest("Invalid project ID.");
            }

            Project project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound("Project not found.");
            }

            project.Category = _categoryService.GetById(project.CategoryId);
            project.Comments = _commentCategory.GetAll().AsQueryable().Include(c => c.Image).Include(c => c.User).Where(c => c.ProjectId == project.Id).Include(c => c.LikedComments).ThenInclude(l=>l.User).ToList();
            project.Image = _imageService.GetById(project.ImageId);
            var user = _userManager.FindByIdAsync((project.UserId + "")).Result;
            if (user != null && user.ProfilePictureId.HasValue)
            {
                Image userImage = _imageService.GetById(user.ProfilePictureId.Value);
                user.ProfilePicture = userImage;
            }
            project.User = user;

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool hasLiked = false;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                int count = project.Comments.Where(c => (c.UserId + "").Equals(currentUserId)).Count();
                hasLiked = count == 1;
            }
            ViewBag.HasLiked = hasLiked;

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
                return RedirectToAction(viewModel.Id+"");
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
