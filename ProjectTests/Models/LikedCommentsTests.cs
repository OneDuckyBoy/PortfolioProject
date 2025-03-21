using NUnit.Framework;
using Portfolio.Models;

namespace ProjectTests
{
    public class LikedCommentsTests
    {
        [Test]
        public void LikedComments_UserId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedComment = new LikedComments();
            var userId = 1;

            // Act
            likedComment.UserId = userId;

            // Assert
            Assert.AreEqual(userId, likedComment.UserId);
        }

        [Test]
        public void LikedComments_User_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedComment = new LikedComments();
            var user = new User { Id = 1, UserName = "testUser" };

            // Act
            likedComment.User = user;

            // Assert
            Assert.AreEqual(user, likedComment.User);
        }

        [Test]
        public void LikedComments_CommentId_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedComment = new LikedComments();
            var commentId = 1;

            // Act
            likedComment.CommentId = commentId;

            // Assert
            Assert.AreEqual(commentId, likedComment.CommentId);
        }

        [Test]
        public void LikedComments_Comment_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var likedComment = new LikedComments();
            var comment = new Comment { Id = 1, Text = "Test Comment" };

            // Act
            likedComment.Comment = comment;

            // Assert
            Assert.AreEqual(comment, likedComment.Comment);
        }
    }
}



