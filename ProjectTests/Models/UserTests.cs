using NUnit.Framework;
using Portfolio.Models;
using System;
using System.Collections.Generic;

namespace ProjectTests
{
    public class UserTests
    {
        [Test]
        public void User_ProfilePictureId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var user = new User();
            int? profilePictureId = 1;

            // Act
            user.ProfilePictureId = profilePictureId;

            // Assert
            Assert.AreEqual(profilePictureId, user.ProfilePictureId);
        }

        [Test]
        public void User_ProfilePicture_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var user = new User();
            var profilePicture = new Image { Id = 1, Path = "path/to/image" };

            // Act
            user.ProfilePicture = profilePicture;

            // Assert
            Assert.AreEqual(profilePicture, user.ProfilePicture);
        }

        [Test]
        public void User_DateCreated_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var user = new User();
            var dateCreated = DateTime.UtcNow;

            // Act
            user.DateCreated = dateCreated;

            // Assert
            Assert.AreEqual(dateCreated, user.DateCreated);
        }

        [Test]
        public void User_DateUpdated_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var user = new User();
            var dateUpdated = DateTime.UtcNow;

            // Act
            user.DateUpdated = dateUpdated;

            // Assert
            Assert.AreEqual(dateUpdated, user.DateUpdated);
        }

        [Test]
        public void User_Projects_ShouldInitializeCorrectly()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNotNull(user.Projects);
            Assert.IsInstanceOf<List<Project>>(user.Projects);
        }

        [Test]
        public void User_LikedComments_ShouldInitializeCorrectly()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNotNull(user.LikedComments);
            Assert.IsInstanceOf<List<LikedComments>>(user.LikedComments);
        }

        [Test]
        public void User_LikedProjects_ShouldInitializeCorrectly()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNotNull(user.LikedProjects);
            Assert.IsInstanceOf<List<LikedProjects>>(user.LikedProjects);
        }
    }
}





