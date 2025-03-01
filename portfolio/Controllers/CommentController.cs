using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Models;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace Portfolio.Controllers
{
    public class CommentController : Controller
    {
        public IService<Comment> _commentService { get; set; }
        public IService<Project> _ProjectService { get; set; }

        private readonly UserManager<User> _userManager;

        public IService<LikedComments> _likedCommentsService { get; set; }

        private readonly IImageUploadService _imageUploadService;

        public IService<Image> _imageService { get; set; }


        public CommentController(IService<Comment> commentService, IService<Project> projectService, UserManager<User> userManager, IService<LikedComments> likedCommentsService, IImageUploadService imageUploadService, IService<Image> imageService)
        {
            _commentService = commentService;
            _ProjectService = projectService;
            _userManager = userManager;
            _likedCommentsService = likedCommentsService;
            _imageUploadService = imageUploadService;
            _imageService = imageService;
        }

        [HttpGet("Comment/IsLikedByUser/{commentId}/{userId}")]
        public IActionResult IsLikedByUser(int commentId, int userId)
        {
            var comment = _commentService.GetById(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            var isLiked = comment.LikedComments.Any(lc => lc.UserId == userId);
            return Json(new { isLiked });
        }

        [HttpPost("Comment/LikeComment/{commentId}/{username}")]
        public async Task<IActionResult> LikeComment(int commentId, string username)
        {
            var comment = _commentService.GetById(commentId);
            if (comment == null)
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(username);
            //var currUser = await _userManager.GetUserAsync(User);//1;//
            var userId1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currUser = await _userManager.FindByIdAsync(userId1);

            int userId = user.Id;
            var likedComment = comment.LikedComments.FirstOrDefault(lc => lc.UserId == currUser.Id);
            if (likedComment == null)
            {
                comment.LikedComments.Add(new LikedComments { UserId = currUser.Id, CommentId = commentId });
                Console.WriteLine(  );
            }

            _commentService.Update(comment);

            var likeCount = comment.LikedComments.Count;
            var liked = likedComment == null;

            return Json(new { liked, likeCount });
        }

        [HttpPost("Comment/removeLikeFromComment/{commentId}/{username}")]
        public async Task<IActionResult> RemoveLikeFromComment(int commentId, string username)
        {
            var comment = _commentService.GetById(commentId);
             
           // var currUser = _userManager.GetUserAsync(User);//1;//
            
            var userId = _userManager.GetUserAsync(User).Result.Id; //_userManager.FindByNameAsync(username).Result.Id;
            var likedComment = _likedCommentsService.GetAll().AsQueryable().Where(c => c.CommentId == commentId).Where(c => c.UserId == userId).ToArray();
            var likeCount = comment.LikedComments.Count;
            if (!likedComment.IsNullOrEmpty())
            {
                var allComments = _likedCommentsService.GetAll().ToList();
                _likedCommentsService.DeleteFromLikedComments(commentId, userId);


                //comment.LikedComments.Remove(likedComment[0]);

                Console.WriteLine();
            }
            bool asd = !likedComment.IsNullOrEmpty();

            var likedCommentIsGone = _likedCommentsService.GetAll().AsQueryable().Where(c => c.CommentId == commentId).Where(c => c.UserId == userId).ToArray().IsNullOrEmpty();

            Console.WriteLine(likedCommentIsGone);
            return Json(new { removed = likedComment != null, likeCount });
        }




        [HttpGet("Comment/GetLikeCount/{commentId}")]
        public IActionResult GetLikeCount(int commentId)
        {
            var comment = _commentService.GetById(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            var likeCount = comment.LikedComments.Count;
            return Json(new { likeCount });
        }
        public ActionResult Index(CommentIndexFilterView filter)
        {
            var query = _commentService.GetAll().AsQueryable();

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

                _commentService.Add(comment);
                return RedirectToAction("Index");
            }

            // Repopulate the Projects SelectList in case of validation failure
            viewModel.Projects = new SelectList(_ProjectService.GetAll(), "Id", "Title");
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var comment = _commentService.GetById(id);
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

                var comment = _commentService.GetById(viewModel.Id);
                if (comment == null)
                {
                    return NotFound();
                }

                comment.Text = viewModel.Text;
                comment.ProjectId = viewModel.ProjectId;
                comment.UserId = user.Id;

                _commentService.Update(comment);
                return RedirectToAction("Index");
            }

            // Repopulate the Projects SelectList in case of validation failure
            viewModel.Projects = new SelectList(_ProjectService.GetAll(), "Id", "Title");
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var comment = _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Project = _ProjectService.GetById(comment.ProjectId);
            comment.User = _userManager.FindByIdAsync(comment.UserId.ToString()).Result;

            return View(comment);
        }


        [HttpPost("Comment/ToggleLike/{commentId}")]
        public async Task<IActionResult> ToggleLike(int commentId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            //var comment = _commentService.GetById(commentId);
            var comment = _commentService.GetAll().FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                return NotFound();
            }

            var likedComment = comment.LikedComments.FirstOrDefault(lc => lc.UserId == user.Id);

            if (likedComment != null)
            {
                // Ако вече е харесан → махаме го (отхаресване)
                comment.LikedComments.Remove(likedComment);
            }
            else
            {
                // Ако не е харесан → добавяме харесване
                comment.LikedComments.Add(new LikedComments { UserId = user.Id, CommentId = commentId });
            }

            _commentService.Update(comment);

            var likeCount = comment.LikedComments.Count;
            var isLiked = likedComment == null; // true ако е харесан, false ако е отхаресан

            return Json(new { isLiked, likeCount });
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(int projectId, string commentText, IFormFile commentImage)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var comment = new Comment
            {
                Text = commentText,
                ProjectId = projectId,
                UserId = user.Id,
                DateAdded = DateTime.Now
            };

            if (commentImage != null && commentImage.Length > 0)
            {
                var imageUrl = await _imageUploadService.UploadImageAsync(commentImage);
                var image = new Image { Path = imageUrl };
                _imageService.Add(image);
                comment.ImageId = image.Id;
            }
            comment.Text = "";
            _commentService.Add(comment);
            //return RedirectToAction("Project1", new { id = projectId });
            return RedirectToAction("Project1", "Project", new { id = projectId });
        }

    }
}
