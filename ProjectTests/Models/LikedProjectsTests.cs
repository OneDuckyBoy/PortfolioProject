using NUnit.Framework;
using Portfolio.Models;

namespace ProjectTests
{
    public class LikedProjectsTests
    {
        [Test]
        public void LikedProjects_UserId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedProject = new LikedProjects();
            var userId = 1;

            // Act
            likedProject.UserId = userId;

            // Assert
            Assert.AreEqual(userId, likedProject.UserId);
        }

        [Test]
        public void LikedProjects_User_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedProject = new LikedProjects();
            var user = new User { Id = 1, UserName = "testUser" };

            // Act
            likedProject.User = user;

            // Assert
            Assert.AreEqual(user, likedProject.User);
        }

        [Test]
        public void LikedProjects_ProjectId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedProject = new LikedProjects();
            var projectId = 1;

            // Act
            likedProject.ProjectId = projectId;

            // Assert
            Assert.AreEqual(projectId, likedProject.ProjectId);
        }

        [Test]
        public void LikedProjects_Project_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedProject = new LikedProjects();
            var project = new Project { Id = 1, Title = "Test Project" };

            // Act
            likedProject.Project = project;

            // Assert
            Assert.AreEqual(project, likedProject.Project);
        }
    }
}




