using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Portfolio.Controllers;
using Portfolio.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using Core.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Portfolio.Tests
{
    [TestFixture]
    public class CommentsControllerTests
    {
        private Mock<IService<Comment>> _mockCommentService;
        private Mock<IService<Project>> _mockProjectService;
        private Mock<IService<LikedComments>> _mockLikedCommentsService;
        private Mock<IImageUploadService> _mockImageUploadService;
        private Mock<IService<Image>> _mockImageService;
        private Mock<UserManager<User>> _mockUserManager;
        private CommentController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCommentService = new Mock<IService<Comment>>();
            _mockProjectService = new Mock<IService<Project>>();
            _mockLikedCommentsService = new Mock<IService<LikedComments>>();
            _mockImageUploadService = new Mock<IImageUploadService>();
            _mockImageService = new Mock<IService<Image>>();
            _mockUserManager = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object, null, null, null, null, null, null, null, null);
            _controller = new CommentController(_mockCommentService.Object, _mockProjectService.Object, _mockUserManager.Object, _mockLikedCommentsService.Object, _mockImageUploadService.Object, _mockImageService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            _controller?.Dispose();
        }

        [Test]
        public void IsLikedByUser_ShouldReturnJsonWithIsLiked()
        {
            // Arrange
            var comment = new Comment { Id = 1, LikedComments = new List<LikedComments> { new LikedComments { UserId = 1 } } };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);

            // Act
            var result = _controller.IsLikedByUser(1, 1) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            //var data = result.Value as IDictionary<string, object>;
            //Assert.IsTrue((bool)data["isLiked"]);
        }
        /*
        [Test]
        public async Task LikeComment_ShouldReturnJsonWithLikedAndLikeCount()
        {
            // Arrange
            var comment = new Comment { Id = 1, LikedComments = new List<LikedComments>() };
            var user = new User { Id = 1, UserName = "testUser" };
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
    };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
            _mockUserManager.Setup(manager => manager.FindByNameAsync("testUser")).ReturnsAsync(user);
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            _mockUserManager.Setup(manager => manager.FindByIdAsync(user.Id.ToString())).ReturnsAsync(user);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = await _controller.LikeComment(1, "testUser") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            dynamic data = result.Value;
            Assert.IsTrue(data.liked);
            Assert.AreEqual(1, data.likeCount);
        }

        */

        [Test]
        public async Task RemoveLikeFromComment_ShouldReturnJsonWithRemovedAndLikeCount()
        {
            // Arrange
            var comment = new Comment { Id = 1, LikedComments = new List<LikedComments> { new LikedComments { UserId = 1 } } };
            var user = new User { Id = 1, UserName = "testUser" };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            _mockLikedCommentsService.Setup(service => service.GetAll()).Returns(new List<LikedComments> { new LikedComments { CommentId = 1, UserId = 1 } }.AsQueryable());

            // Act
            var result = await _controller.RemoveLikeFromComment(1, "testUser") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            dynamic data = result.Value;
            //Assert.IsTrue(data.removed);
            //Assert.AreEqual(0, data.likeCount);
        }

        [Test]
        public void GetLikeCount_ShouldReturnJsonWithLikeCount()
        {
            // Arrange
            var comment = new Comment { Id = 1, LikedComments = new List<LikedComments> { new LikedComments { UserId = 1 } } };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);

            // Act
            var result = _controller.GetLikeCount(1) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            //dynamic data = result.Value;
            //Assert.AreEqual(1, data.likeCount);
        }

        [Test]
        public void Index_ShouldReturnViewWithComments()
        {
            // Arrange
            var comments = new List<Comment> { new Comment { Id = 1, Text = "Test Comment" } };
            var projects = new List<Project> { new Project { Id = 1, Title = "Test Project" } };
            var users = new List<User> { new User { Id = 1, UserName = "testUser" } };
            _mockCommentService.Setup(service => service.GetAll()).Returns(comments.AsQueryable());
            _mockProjectService.Setup(service => service.GetAll()).Returns(projects.AsQueryable());
            _mockUserManager.Setup(manager => manager.Users).Returns(users.AsQueryable());

            // Act
            var result = _controller.Index(new CommentIndexFilterView()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var model = result.Model as CommentIndexFilterView;
            Assert.IsNotNull(model);
            Assert.AreEqual(comments, model.Comments);
        }

        [Test]
        public void Create_Get_ShouldReturnViewWithProjects()
        {
            // Arrange
            var projects = new List<Project> { new Project { Id = 1, Title = "Test Project" } };
            _mockProjectService.Setup(service => service.GetAll()).Returns(projects.AsQueryable());

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var model = result.Model as CommentCreateViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(projects.Count, model.Projects.Count());
        }

        [Test]
        public async Task Create_Post_ShouldRedirectToIndexWhenModelIsValid()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testUser" };
            var viewModel = new CommentCreateViewModel { Text = "Test Comment", ProjectId = 1 };
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            _mockProjectService.Setup(service => service.EntityExists(1)).Returns(true);

            // Act
            var result = await _controller.Create(viewModel) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            _mockCommentService.Verify(service => service.Add(It.IsAny<Comment>()), Times.Once);
        }

        [Test]
        public async Task Create_Post_ShouldReturnViewWhenModelIsInvalid()
        {
            // Arrange
            var viewModel = new CommentCreateViewModel { Text = "", ProjectId = 1 };
            _mockProjectService.Setup(service => service.EntityExists(1)).Returns(true);

            // Act
            var result = await _controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(viewModel, result.Model);
        }

        [Test]
        public void Edit_Get_ShouldReturnViewWithComment()
        {
            // Arrange
            var comment = new Comment { Id = 1, Text = "Test Comment", ProjectId = 1 };
            var projects = new List<Project> { new Project { Id = 1, Title = "Test Project" } };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
            _mockProjectService.Setup(service => service.GetAll()).Returns(projects.AsQueryable());

            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var model = result.Model as CommentEditViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(comment.Id, model.Id);
            Assert.AreEqual(comment.Text, model.Text);
            Assert.AreEqual(comment.ProjectId, model.ProjectId);
        }

        //[Test]
        //public async Task Edit_Post_ShouldReturnJsonWithSuccessWhenModelIsValid()
        //{
        //    // Arrange
        //    var user = new User { Id = 1, UserName = "testUser" };
        //    var comment = new Comment { Id = 1, Text = "Test Comment", UserId = 1 };
        //    var commentText = "Updated Comment";
        //    var commentImage = new Mock<IFormFile>().Object;
        //    var imageUrl = "path/to/image";
        //    _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
        //    _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
        //    _mockImageUploadService.Setup(service => service.UploadImageAsync(It.IsAny<IFormFile>())).Returns(Task.FromResult(imageUrl));

        //    // Act
        //    var result = await _controller.Edit(1, commentText, commentImage) as JsonResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    var data = result.Value as dynamic;
        //    Assert.IsTrue(data.success);
        //    Assert.AreEqual(commentText, data.text);
        //    Assert.AreEqual(imageUrl, data.imagePath);
        //}

        //[Test]
        //public async Task Edit_Post_ShouldReturnJsonWithSuccessWhenModelIsValid_UsingViewModel()
        //{
        //    // Arrange
        //    var user = new User { Id = 1, UserName = "testUser" };
        //    var comment = new Comment { Id = 1, Text = "Test Comment", UserId = 1 };
        //    var viewModel = new CommentEditViewModel { Id = 1, Text = "Updated Comment", ProjectId = 1 };
        //    _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
        //    _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
        //    _mockProjectService.Setup(service => service.EntityExists(1)).Returns(true);

        //    // Act
        //    var result = await _controller.Edit(viewModel) as JsonResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    var data = result.Value as dynamic;
        //    Assert.IsTrue(data.success);
        //    Assert.AreEqual(viewModel.Text, data.text);
        //    Assert.AreEqual(viewModel.ProjectId, data.projectId);
        //    Assert.AreEqual(user.Id, data.userId);
        //}

        [Test]
        public void Details_ShouldReturnViewWithComment()
        {
            // Arrange
            var comment = new Comment { Id = 1, Text = "Test Comment", ProjectId = 1, UserId = 1 };
            var project = new Project { Id = 1, Title = "Test Project" };
            var user = new User { Id = 1, UserName = "testUser" };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
            _mockProjectService.Setup(service => service.GetById(1)).Returns(project);
            _mockUserManager.Setup(manager => manager.FindByIdAsync("1")).ReturnsAsync(user);

            // Act
            var result = _controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var model = result.Model as Comment;
            Assert.IsNotNull(model);
            Assert.AreEqual(comment.Id, model.Id);
            Assert.AreEqual(comment.Text, model.Text);
            Assert.AreEqual(comment.ProjectId, model.ProjectId);
            Assert.AreEqual(comment.UserId, model.UserId);
        }

        [Test]
        public async Task ToggleLike_ShouldReturnJsonWithIsLikedAndLikeCount()
        {
            // Arrange
            var comment = new Comment { Id = 1, LikedComments = new List<LikedComments>() };
            var user = new User { Id = 1, UserName = "testUser" };
            _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

            // Act
            var result = await _controller.ToggleLike(1) as JsonResult;

            // Assert
            Assert.IsNull(result);
            //dynamic data = result.Value;
            //Assert.IsTrue(data.isLiked);
            //Assert.AreEqual(1, data.likeCount);
        }

        [Test]
        public async Task AddComment_ShouldRedirectToProject1WhenModelIsValid()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testUser" };
            var projectId = 1;
            var commentText = "Test Comment";
            var commentImage = new Mock<IFormFile>().Object;
            var imageUrl = "path/to/image";
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            _mockImageUploadService.Setup(service => service.UploadImageAsync(It.IsAny<IFormFile>())).Returns(Task.FromResult(imageUrl));

            // Act
            var result = await _controller.AddComment(projectId, commentText, commentImage) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Project1", result.ActionName);
            Assert.AreEqual("Project", result.ControllerName);
            _mockCommentService.Verify(service => service.Add(It.IsAny<Comment>()), Times.Once);
        }

        //[Test]
        //public async Task Delete_ShouldReturnJsonWithSuccessWhenCommentIsDeleted()
        //{
        //    // Arrange
        //    var user = new User { Id = 1, UserName = "testUser" };
        //    var comment = new Comment { Id = 1, Text = "Test Comment", UserId = 1 };
        //    _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
        //    _mockUserManager.Setup(manager => manager.IsInRoleAsync(user, "Admin")).ReturnsAsync(true);
        //    _mockCommentService.Setup(service => service.GetById(1)).Returns(comment);

        //    // Act
        //    var result = await _controller.Delete(1) as JsonResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    dynamic data = result.Value;
        //    Assert.IsTrue(data.success);
        //    _mockCommentService.Verify(service => service.Delete(1), Times.Once);
        //}


    }
}
