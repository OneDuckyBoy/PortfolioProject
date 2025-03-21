using NUnit.Framework;
using Portfolio.Models;
using System;

namespace ProjectTests
{
    public class CommentTests
    {
        [Test]
        public void Comment_Text_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var text = "This is a test comment.";

            // Act
            comment.Text = text;

            // Assert
            Assert.AreEqual(text, comment.Text);
        }

        [Test]
        public void Comment_ProjectId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var projectId = 1;

            // Act
            comment.ProjectId = projectId;

            // Assert
            Assert.AreEqual(projectId, comment.ProjectId);
        }

        [Test]
        public void Comment_Project_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var project = new Project { Id = 1, Title = "Test Project" };

            // Act
            comment.Project = project;

            // Assert
            Assert.AreEqual(project, comment.Project);
        }

        [Test]
        public void Comment_UserId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var userId = 1;

            // Act
            comment.UserId = userId;

            // Assert
            Assert.AreEqual(userId, comment.UserId);
        }

        [Test]
        public void Comment_User_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var user = new User { Id = 1, UserName = "testUser" };

            // Act
            comment.User = user;

            // Assert
            Assert.AreEqual(user, comment.User);
        }

        [Test]
        public void Comment_ImageId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            int? imageId = 1;

            // Act
            comment.ImageId = imageId;

            // Assert
            Assert.AreEqual(imageId, comment.ImageId);
        }

        [Test]
        public void Comment_Image_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var image = new Image { Id = 1, Path = "path/to/image" };

            // Act
            comment.Image = image;

            // Assert
            Assert.AreEqual(image, comment.Image);
        }

        [Test]
        public void Comment_DateAdded_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var comment = new Comment();
            var dateAdded = DateTime.UtcNow;

            // Act
            comment.DateAdded = dateAdded;

            // Assert
            Assert.AreEqual(dateAdded, comment.DateAdded);
        }

        [Test]
        public void Comment_LikedComments_ShouldInitializeCorrectly()
        {
            // Arrange
            var comment = new Comment();

            // Act & Assert
            Assert.IsNotNull(comment.LikedComments);
            Assert.IsInstanceOf<System.Collections.Generic.List<LikedComments>>(comment.LikedComments);
        }
    }
}



