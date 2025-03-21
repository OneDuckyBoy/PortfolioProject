using NUnit.Framework;
using Portfolio.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTests
{
    public class CategoryTests
    {
        [Test]
        public void Category_Name_ShouldBeRequired()
        {
            // Arrange
            var category = new Category { Name = null };

            // Act
            var validationResults = ValidateModel(category);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Name") && v.ErrorMessage.Contains("required")));
        }

        [Test]
        public void Category_Name_ShouldHaveMaxLength()
        {
            // Arrange
            var category = new Category { Name = new string('a', 101) };

            // Act
            var validationResults = ValidateModel(category);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Name") && v.ErrorMessage.Contains("maximum length")));
        }

        [Test]
        public void Category_Name_ShouldHaveMinLength()
        {
            // Arrange
            var category = new Category { Name = "a" };

            // Act
            var validationResults = ValidateModel(category);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Name") && v.ErrorMessage.Contains("minimum length")));
        }

        [Test]
        public void Category_Description_ShouldHaveMaxLength()
        {
            // Arrange
            var category = new Category { Description = new string('a', 501) };

            // Act
            var validationResults = ValidateModel(category);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Description") && v.ErrorMessage.Contains("maximum length")));
        }

        [Test]
        public void Category_Description_ShouldHaveMinLength()
        {
            // Arrange
            var category = new Category { Description = "a" };

            // Act
            var validationResults = ValidateModel(category);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Description") && v.ErrorMessage.Contains("minimum length")));
        }

        [Test]
        public void Category_ShouldInitializeProjectsCollection()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.IsNotNull(category.Projects);
            Assert.IsInstanceOf<List<Project>>(category.Projects);
        }

        [Test]
        public void Category_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.AreEqual(string.Empty, category.Name);
            Assert.AreEqual(string.Empty, category.Description);
            Assert.IsNotNull(category.Projects);
            Assert.IsInstanceOf<List<Project>>(category.Projects);
        }
        [Test]
        public void CategoryImageSavesProperly()
        {
            // Arrange
            Image testImage = new Image();
            string path = "test path";
            testImage.Path = path;
            var category = new Category { Image =  testImage};
            // Act
            var result = category.Image;

            // Assert
            Assert.AreEqual(category.Image, result);
            Assert.AreEqual(category.Image.Path, path);
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