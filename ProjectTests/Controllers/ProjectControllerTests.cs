using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Portfolio.Controllers;
using Portfolio.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace ProjectTests
{
    public class ProjectControllerTests
    {
        private Mock<IService<Project>> _mockProjectService;
        private Mock<IService<Image>> _mockImageService;
        private Mock<IService<Category>> _mockCategoryService;
        private Mock<IService<Comment>> _mockCommentService;
        private Mock<IImageUploadService> _mockImageUploadService;
        private Mock<UserManager<User>> _mockUserManager;
        private Mock<SignInManager<User>> _mockSignInManager;
        private Mock<IService<LikedProjects>> _mockLikedProjectsService;
        private ProjectController _controller;

        [SetUp]
        public void Setup()
        {
            _mockProjectService = new Mock<IService<Project>>();
            _mockImageService = new Mock<IService<Image>>();
            _mockCategoryService = new Mock<IService<Category>>();
            _mockCommentService = new Mock<IService<Comment>>();
            _mockImageUploadService = new Mock<IImageUploadService>();
            _mockUserManager = MockUserManager();
            _mockSignInManager = MockSignInManager();
            _mockLikedProjectsService = new Mock<IService<LikedProjects>>();

            _controller = new ProjectController(
                _mockProjectService.Object,
                _mockImageService.Object,
                _mockCategoryService.Object,
                _mockUserManager.Object,
                _mockSignInManager.Object,
                _mockImageUploadService.Object,
                _mockCommentService.Object,
                _mockLikedProjectsService.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public void Index_ReturnsViewResult_WithModel()
        {
            // Arrange
            var filter = new ProjectIndexFilterModelView();
            _mockProjectService.Setup(service => service.GetAll()).Returns(new List<Project>().AsQueryable());

            // Act
            var result = _controller.Index(filter);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ProjectIndexFilterModelView>(viewResult.Model);
        }

        [Test]
        public void All_ReturnsViewResult_WithModel()
        {
            // Arrange
            var filter = new ProjectIndexFilterModelView();
            _mockProjectService.Setup(service => service.GetAll()).Returns(new List<Project>().AsQueryable());

            // Act
            var result = _controller.All(filter);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ProjectIndexFilterModelView>(viewResult.Model);
        }

        [Test]
        public void Create_Get_ReturnsViewResult_WithModel()
        {
            // Arrange
            _mockCategoryService.Setup(service => service.GetAll()).Returns(new List<Category>());

            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ProjectCreateViewModel>(viewResult.Model);
        }

        [Test]
        public void Create_Post_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var viewModel = new ProjectCreateViewModel
            {
                Title = "Test Project",
                ShortDescription = "Test Description",
                Description = "Test Full Description",
                CategoryId = 1,
                Image = Mock.Of<IFormFile>()
            };
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new User());
            _mockImageUploadService.Setup(service => service.UploadImageAsync(It.IsAny<IFormFile>())).ReturnsAsync("test/path");
            _mockImageService.Setup(service => service.Add(It.IsAny<Image>())).Returns(new Image { Path = "test/path" });
            _mockCategoryService.Setup(service => service.GetById(It.IsAny<int>())).Returns(new Category());

            // Act
            var result = _controller.CreateAsync(viewModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var viewModel = new ProjectCreateViewModel();
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = _controller.CreateAsync(viewModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Details_ReturnsViewResult_WithModel()
        {
            // Arrange
            var projectId = 1;
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });

            // Act
            var result = _controller.Details(projectId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<Project>(viewResult.Model);
        }

        
        /*
        [Test]
        public async Task Like_ReturnsJsonResult()
        {
            // Arrange
            var projectId = 1;
            var username = "testuser";
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });
            _mockUserManager.Setup(manager => manager.FindByNameAsync(username)).ReturnsAsync(new User { Id = 1 });
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new User { Id = 1 });

            // Act
            var result = await _controller.Like(projectId, username);

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }
        */
        [Test]
        public async Task RemoveLikeFromProject_ReturnsJsonResult()
        {
            // Arrange
            var projectId = 1;
            var username = "testuser";
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });
            _mockUserManager.Setup(manager => manager.FindByNameAsync(username)).ReturnsAsync(new User { Id = 1 });
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new User { Id = 1 });

            // Act
            var result = await _controller.RemoveLikeFromProject(projectId, username);

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public async Task LikedProjects_ReturnsViewResult_WithModel()
        {
            // Arrange
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new User { Id = 1 });
            _mockProjectService.Setup(service => service.GetAll()).Returns(new List<Project>().AsQueryable());

            // Act
            var result = await _controller.LikedProjects();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<List<Project>>(viewResult.Model);
        }
        /*
        [Test]
        public void Project1_ReturnsViewResult_WithModel()
        {
            // Arrange
            var projectId = 1;
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });
            _mockUserManager.Setup(manager => manager.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new User());

            // Act
            var result = _controller.Project1(projectId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<Project>(viewResult.Model);
        }*/
        /*
        [Test]
        public void Edit_Get_ReturnsViewResult_WithModel()
        {
            // Arrange
            var projectId = 1;
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });
            _mockCategoryService.Setup(service => service.GetAll()).Returns(new List<Category>());

            // Act
            var result = _controller.Edit(projectId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<ProjectEditViewModel>(viewResult.Model);
        }
        */
        [Test]
        public void Edit_Post_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var viewModel = new ProjectEditViewModel
            {
                Id = 1,
                Title = "Test Project",
                ShortDescription = "Test Description",
                Description = "Test Full Description",
                CategoryId = 1
            };
            _mockProjectService.Setup(service => service.GetById(viewModel.Id)).Returns(new Project { Id = viewModel.Id });

            // Act
            var result = _controller.Edit(viewModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void Edit_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var viewModel = new ProjectEditViewModel();
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = _controller.Edit(viewModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Delete_Get_ReturnsViewResult_WithModel()
        {
            // Arrange
            var projectId = 1;
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(new Project { Id = projectId });

            // Act
            var result = _controller.Delete(projectId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<Project>(viewResult.Model);
        }
        /*
        [Test]
        public void Delete_Post_ReturnsRedirectToActionResult()
        {
            // Arrange
            var projectId = 1;
            var project = new Project { Id = projectId };
            _mockProjectService.Setup(service => service.GetById(projectId)).Returns(project);

            // Act
            var result = _controller.Delete(project.Id);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        */
        private Mock<UserManager<User>> MockUserManager()
        {
            var store = new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
        }

        private Mock<SignInManager<User>> MockSignInManager()
        {
            var userManager = MockUserManager();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<User>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<User>>();

            return new Mock<SignInManager<User>>(
                userManager.Object,
                contextAccessor.Object,
                userPrincipalFactory.Object,
                options.Object,
                logger.Object,
                schemes.Object,
                confirmation.Object
            );
        }
    }
}
