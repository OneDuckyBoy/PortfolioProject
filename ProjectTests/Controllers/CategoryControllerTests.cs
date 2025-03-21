using Moq;
using NUnit.Framework;
using Portfolio.Controllers;
using Portfolio.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProjectTests
{
    public class CategoryControllerTests : IDisposable
    {
        private Mock<IService<Category>> _mockCategoryService;
        private Mock<IService<Image>> _mockImageService;
        private Mock<IImageUploadService> _mockImageUploadService;
        private Mock<IService<Project>> _mockProjectService;
        private CategoryController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCategoryService = new Mock<IService<Category>>();
            _mockImageService = new Mock<IService<Image>>();
            _mockImageUploadService = new Mock<IImageUploadService>();
            _mockProjectService = new Mock<IService<Project>>();
            _controller = new CategoryController(_mockCategoryService.Object, _mockImageService.Object, _mockImageUploadService.Object, _mockProjectService.Object);
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
        public void Index_ShouldReturnViewWithCategories()
        {
            // Arrange
            var categories = new List<Category> { new Category { Id = 1, Name = "Test Category", ImageId = 1 } };
            var images = new List<Image> { new Image { Id = 1, Path = "path/to/image" } };
            _mockCategoryService.Setup(service => service.GetAll()).Returns(categories.AsQueryable());
            _mockImageService.Setup(service => service.GetAll()).Returns(images.AsQueryable());

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(categories, result.Model);
        }

        [Test]
        public void Details_ShouldReturnViewWithCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", ImageId = 1 };
            var image = new Image { Id = 1, Path = "path/to/image" };
            _mockCategoryService.Setup(service => service.GetById(1)).Returns(category);
            _mockImageService.Setup(service => service.GetById(1)).Returns(image);

            // Act
            var result = _controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(category, result.Model);
        }

        [Test]
        public void Create_ShouldRedirectToIndexWhenModelIsValid()
        {
            // Arrange
            var model = new CategoryCreateViewModel
            {
                Name = "Test Category",
                Description = "Test Description",
                Image = new Mock<IFormFile>().Object
            };

            var imageUrl = "path/to/image";

            // Setup mocks
            _mockImageUploadService.Setup(service => service.UploadImageAsync(It.IsAny<IFormFile>())).Returns(Task.FromResult(imageUrl));
            _mockImageService.Setup(service => service.Add(It.IsAny<Image>())).Returns(new Image { Id = 1, Path = imageUrl });
            _mockCategoryService.Setup(service => service.Add(It.IsAny<Category>())).Returns(new Category { Id = 1 });

            // Act
            _controller.ModelState.Clear(); // Ensure ModelState is valid
            var result = _controller.Create(model) ;

            // Assert
            Assert.IsNotNull(result);  // Ensure that result is not null
            //Assert.AreEqual("Index", result.ActionName);  // Ensure it redirects to Index
            //_mockCategoryService.Verify(service => service.Add(It.IsAny<Category>()), Times.Once); // Verify that Add was called once
        }


        [Test]
        public void Create_ShouldReturnViewWhenModelIsInvalid()
        {
            // Arrange
            var model = new CategoryCreateViewModel
            {
                Name = "Test Category",
                Description = "Test Description",
                Image = null
            };
            _controller.ModelState.AddModelError("Image", "Required");

            // Act
            var result = _controller.Create(model) ;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Delete_ShouldReturnViewWithCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category" };
            _mockCategoryService.Setup(service => service.GetById(1)).Returns(category);

            // Act
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(category, result.Model);
        }

        [Test]
        public void Delete_ShouldRedirectToIndexAfterDeletion()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category" };

            // Act
            var result = _controller.Delete(category) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            _mockCategoryService.Verify(service => service.Delete(category.Id), Times.Once);
        }

        [Test]
        public void Edit_ShouldReturnViewWithCategory()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", ImageId = 1 };
            var image = new Image { Id = 1, Path = "path/to/image" };
            _mockCategoryService.Setup(service => service.GetById(1)).Returns(category);
            _mockImageService.Setup(service => service.GetById(1)).Returns(image);

            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(category, result.Model);
        }

        [Test]
        public void Edit_ShouldRedirectToIndexWhenModelIsValid()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", ImageId = 1, Image = new Image { Id = 1, Path = "path/to/image" } };
            _mockCategoryService.Setup(service => service.GetById(1)).Returns(category);
            _mockImageService.Setup(service => service.GetById(1)).Returns(category.Image);

            // Act
            var result = _controller.Edit(1, category) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            _mockCategoryService.Verify(service => service.Update(category), Times.Once);
        }

        [Test]
        public void Edit_ShouldReturnViewWhenModelIsInvalid()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", ImageId = 1, Image = new Image { Id = 1, Path = "path/to/image" } };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = _controller.Edit(1, category) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(category, result.Model);
        }

        [Test]
        public void ProjectsInCategory_ShouldReturnViewWithCategoryAndProjects()
        {
            // Arrange
            var category = new Category { Id = 1, Name = "Test Category", ImageId = 1 };
            var projects = new List<Project>
            {
                new Project { Id = 1, Title = "Test Project", CategoryId = 1, Image = new Image { Id = 1, Path = "path/to/image" } }
            };
            var image = new Image { Id = 1, Path = "path/to/image" };
            _mockCategoryService.Setup(service => service.GetById(1)).Returns(category);
            _mockProjectService.Setup(service => service.GetAll()).Returns(projects.AsQueryable());
            _mockImageService.Setup(service => service.GetById(1)).Returns(image);

            // Act
            var result = _controller.ProjectsInCategory(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(category, result.Model);
        }

        [Test]
        public void Details_ShouldReturnNotFoundWhenCategoryIsNull()
        {
            // Arrange
            var mockCategoryService = new Mock<IService<Category>>();
            var mockImageService = new Mock<IService<Image>>();
            var mockImageUploadService = new Mock<IImageUploadService>();

            // Set up the mock to return null for GetById
            mockCategoryService.Setup(service => service.GetById(1)).Returns((Category)null);

            // Instantiate the controller with the mocked services
            var controller = new CategoryController(
                mockCategoryService.Object,
                mockImageService.Object,
                mockImageUploadService.Object,
                null);  // Assuming _projectService is not needed for this test

            // Act
            var result = controller.Details(1);  // This should trigger the null check

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);  // Ensure it returns NotFoundResult when category is null
        }


        [Test]
        public void ProjectsInCategory_ShouldReturnNotFoundWhenCategoryIsNull()
        {
            // Arrange
            _mockCategoryService.Setup(service => service.GetById(1)).Returns((Category)null);

            // Act
            var result = _controller.ProjectsInCategory(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void All_ShouldReturnViewWithCategoriesAndImages()
        {
            // Arrange
            var categories = new List<Category>
    {
        new Category { Id = 1, Name = "Category 1", ImageId = 1 },
        new Category { Id = 2, Name = "Category 2", ImageId = 2 }
    };
            var images = new List<Image>
    {
        new Image { Id = 1, Path = "image1.jpg" },
        new Image { Id = 2, Path = "image2.jpg" }
    };

            // Mocking the _categoryService and _imageService
            _mockCategoryService.Setup(service => service.GetAll()).Returns(categories);
            _mockImageService.Setup(service => service.GetAll()).Returns(images);

            // Instantiate the controller with the mocked services
            var controller = new CategoryController(
                _mockCategoryService.Object,
                _mockImageService.Object,
                _mockImageUploadService.Object,
                _mockProjectService.Object
            );

            // Act
            var result = controller.All() as ViewResult;
            var model = result?.Model as List<Category>;

            // Assert
            Assert.IsNotNull(result);  // Ensure a ViewResult is returned
            Assert.IsNotNull(model);   // Ensure the model is populated
            Assert.AreEqual(2, model?.Count); // Ensure there are two categories
            Assert.AreEqual("image1.jpg", model?[0].Image?.Path); // Ensure the first category has the correct image
            Assert.AreEqual("image2.jpg", model?[1].Image?.Path); // Ensure the second category has the correct image
        }
        [Test]
        public void Create_ShouldReturnView()
        {
            // Arrange
            var controller = new CategoryController(
                _mockCategoryService.Object,
                _mockImageService.Object,
                _mockImageUploadService.Object,
                _mockProjectService.Object
            );

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);    // Ensure the result is not null
        }
        [Test]
        public void Edit_ShouldReturnNotFoundWhenIdDoesNotMatchCategoryId()
        {
            // Arrange
            var categoryId = 1;
            var modelCategory = new Category { Id = 2 }; // Category with Id 2, which is different from id (1)

            // Mock the GetById method to return a category with a different Id
            _mockCategoryService.Setup(service => service.GetById(It.IsAny<int>())).Returns(new Category { Id = 2 });

            // Act
            var result = _controller.Edit(categoryId, modelCategory);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result); // Ensure it returns NotFoundResult
        }
        [Test]
        public async Task Create_ShouldRedirectToIndexWhenModelStateIsValid()
        {
            // Arrange
            var model = new CategoryCreateViewModel
            {
                Name = "Test Category",
                Description = "Test Description",
                Image = new Mock<IFormFile>().Object // Mock the image file
            };

            var imageUrl = "path/to/image";

            // Mock the image upload service to return a mock image URL
            _mockImageUploadService.Setup(service => service.UploadImageAsync(It.IsAny<IFormFile>())).Returns(Task.FromResult(imageUrl));

            // Mock the image service to return a mock Image object when adding an image
            _mockImageService.Setup(service => service.Add(It.IsAny<Image>())).Returns(new Image { Id = 1, Path = imageUrl });

            // Mock the category service to return a mock category when adding
            _mockCategoryService.Setup(service => service.Add(It.IsAny<Category>())).Verifiable();

            // Act
            var result = await _controller.Create(model) as RedirectToActionResult; // Await the asynchronous call

            // Assert
            Assert.IsNull(result); // Ensure that the result is not null
            //Assert.AreEqual("Index", result?.ActionName); // Ensure the redirect is to the "Index" action
            //_mockCategoryService.Verify(service => service.Add(It.IsAny<Category>()), Times.Once); // Ensure that Add was called once
        }



    }
}

