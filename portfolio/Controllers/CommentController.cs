using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CommentController : Controller
    {
        public IService<Comment> _CommentService { get; set; }
        public IService<Project> _ProjectService { get; set; }
        private readonly UserManager<User> _userManager;

        public CommentController(IService<Comment> commentService, IService<Project> projectService, UserManager<User> userManager)
        {
            _CommentService = commentService;
            _ProjectService = projectService;
            _userManager = userManager;
        }
        public ActionResult Index(CommentIndexFilterView filter)
        {
            var query = _CommentService.GetAll().AsQueryable();

            if (filter.ProjectId != null)
            {
                query = query.Where(p => p.ProjectId == filter.ProjectId.Value);
            }
            if (filter.Content != null)
            {
                query = query.Where(p => p.Text.Contains(filter.Content));
            }
            if (filter.UserId != null)
            {
                query = query.Where(p => p.UserId == filter.UserId.Value);
            }
            var model = new CommentIndexFilterView
            {
                Projects = new SelectList(_ProjectService.GetAll(), "Id", "Title"),
                Users = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Comments = query.ToList(),
                ProjectId = filter.ProjectId,
                UserId = filter.UserId,
                Content = filter.Content
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var projects = _ProjectService.GetAll();
            var viewModel = new CommentCreateViewModel
            {
                Projects = new SelectList(projects, "Id", "Title")
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateViewModel viewModel)
        {
            //if (ModelState.IsValid)
            if(_ProjectService.EntityExists(viewModel.ProjectId)&&!viewModel.Text.IsNullOrEmpty())
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                var comment = new Comment
                {
                    Text = viewModel.Text,
                    ProjectId = viewModel.ProjectId,
                    UserId = user.Id,
                    DateAdded = DateTime.Now
                };

                _CommentService.Add(comment);
                return RedirectToAction("Index");
            }

            // Repopulate the Projects SelectList in case of validation failure
            viewModel.Projects = new SelectList(_ProjectService.GetAll(), "Id", "Title");
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var comment = _CommentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            var projects = _ProjectService.GetAll();
            var viewModel = new CommentEditViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                ProjectId = comment.ProjectId,
                Projects = new SelectList(projects, "Id", "Title")
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentEditViewModel viewModel)
        {
            if (_ProjectService.EntityExists(viewModel.ProjectId) && !viewModel.Text.IsNullOrEmpty())
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                var comment = _CommentService.GetById(viewModel.Id);
                if (comment == null)
                {
                    return NotFound();
                }

                comment.Text = viewModel.Text;
                comment.ProjectId = viewModel.ProjectId;
                comment.UserId = user.Id;

                _CommentService.Update(comment);
                return RedirectToAction("Index");
            }

            // Repopulate the Projects SelectList in case of validation failure
            viewModel.Projects = new SelectList(_ProjectService.GetAll(), "Id", "Title");
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var comment = _CommentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Project = _ProjectService.GetById(comment.ProjectId);
            comment.User = _userManager.FindByIdAsync(comment.UserId.ToString()).Result;

            return View(comment);
        }
    }
}
