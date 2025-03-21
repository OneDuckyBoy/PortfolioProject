using NUnit.Framework;
using Portfolio.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ProjectTests
{
    public class ProfileViewModelTests
    {
        [Test]
        public void ProfileViewModel_Username_ShouldBeRequired()
        {
            // Arrange
            var model = new ProfileViewModel { Username = null };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Username") && v.ErrorMessage.Contains("required")));
        }

        [Test]
        public void ProfileViewModel_Email_ShouldBeRequired()
        {
            // Arrange
            var model = new ProfileViewModel { Email = null };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains("required")));
        }


        [Test]
        public void ProfileViewModel_PhoneNumber_ShouldBeValidPhoneNumber()
        {
            // Arrange
            var model = new ProfileViewModel { PhoneNumber = "invalid-phone" };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("PhoneNumber") && v.ErrorMessage.Contains("valid phone number")));
        }

        [Test]
        public void ProfileViewModel_ProfilePicture_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var model = new ProfileViewModel();
            var profilePicture = new Mock<IFormFile>().Object;

            // Act
            model.ProfilePicture = profilePicture;

            // Assert
            Assert.AreEqual(profilePicture, model.ProfilePicture);
        }

        [Test]
        public void ProfileViewModel_ProfilePictureUrl_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var model = new ProfileViewModel();
            var profilePictureUrl = "http://example.com/profile.jpg";

            // Act
            model.ProfilePictureUrl = profilePictureUrl;

            // Assert
            Assert.AreEqual(profilePictureUrl, model.ProfilePictureUrl);
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



