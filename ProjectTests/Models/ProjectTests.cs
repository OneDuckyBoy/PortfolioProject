using NUnit.Framework;
using Portfolio.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTests
{
    public class ProjectTests
    {
        [Test]
        public void Project_Title_ShouldBeRequired()
        {
            // Arrange
            var project = new Project { Title = null };

            // Act
            var validationResults = ValidateModel(project);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Title") && v.ErrorMessage.Contains("required")));
        }

        [Test]
        public void Project_Title_ShouldHaveMaxLength()
        {
            // Arrange
            var project = new Project { Title = new string('a', 151) };

            // Act
            var validationResults = ValidateModel(project);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Title") && v.ErrorMessage.Contains("maximum length")));
        }

        [Test]
        public void Project_ShortDescription_ShouldHaveMaxLength()
        {
            // Arrange
            var project = new Project { ShortDescription = new string('a', 301) };

            // Act
            var validationResults = ValidateModel(project);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("ShortDescription") && v.ErrorMessage.Contains("maximum length")));
        }

        [Test]
        public void Project_Description_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var description = "This is a test description.";

            // Act
            project.Description = description;

            // Assert
            Assert.AreEqual(description, project.Description);
        }

        [Test]
        public void Project_CategoryId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var categoryId = 1;

            // Act
            project.CategoryId = categoryId;

            // Assert
            Assert.AreEqual(categoryId, project.CategoryId);
        }

        [Test]
        public void Project_Category_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var category = new Category { Id = 1, Name = "Test Category" };

            // Act
            project.Category = category;

            // Assert
            Assert.AreEqual(category, project.Category);
        }

        [Test]
        public void Project_Comments_ShouldInitializeCorrectly()
        {
            // Arrange
            var project = new Project();

            // Act & Assert
            Assert.IsNotNull(project.Comments);
            Assert.IsInstanceOf<List<Comment>>(project.Comments);
        }

        [Test]
        public void Project_LikedProjects_ShouldInitializeCorrectly()
        {
            // Arrange
            var project = new Project();

            // Act & Assert
            Assert.IsNotNull(project.LikedProjects);
            Assert.IsInstanceOf<List<LikedProjects>>(project.LikedProjects);
        }

        [Test]
        public void Project_UserId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var userId = 1;

            // Act
            project.UserId = userId;

            // Assert
            Assert.AreEqual(userId, project.UserId);
        }

        [Test]
        public void Project_User_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var user = new User { Id = 1, UserName = "testUser" };

            // Act
            project.User = user;

            // Assert
            Assert.AreEqual(user, project.User);
        }

        [Test]
        public void Project_ImageId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var imageId = 1;

            // Act
            project.ImageId = imageId;

            // Assert
            Assert.AreEqual(imageId, project.ImageId);
        }

        [Test]
        public void Project_Image_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var project = new Project();
            var image = new Image { Id = 1, Path = "path/to/image" };

            // Act
            project.Image = image;

            // Assert
            Assert.AreEqual(image, project.Image);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}




