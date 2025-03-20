using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using NUnit.Framework;
using Portfolio.Data;
using Portfolio.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTests
{
    public class RepositoryTest
    {
        private ApplicationDbContext _context;
        private Repository<Project> _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new Repository<Project>(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void Add_ShouldAddEntity()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };

            // Act
            var result = _repository.Add(project);

            // Assert
            Assert.AreEqual(project, result);
            Assert.AreEqual(1, _context.Set<Project>().Count());
        }

        [Test]
        public void Delete_ShouldRemoveEntity()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };
            _context.Set<Project>().Add(project);
            _context.SaveChanges();

            // Act
            _repository.Delete(project.Id);

            // Assert
            Assert.AreEqual(0, _context.Set<Project>().Count());
        }

        [Test]
        public void GetAll_ShouldReturnAllEntities()
        {
            // Arrange
            var project1 = new Project { Id = 1, Title = "Test Project 1" };
            var project2 = new Project { Id = 2, Title = "Test Project 2" };
            _context.Set<Project>().AddRange(project1, project2);
            _context.SaveChanges();

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetById_ShouldReturnEntity()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };
            _context.Set<Project>().Add(project);
            _context.SaveChanges();

            // Act
            var result = _repository.GetById(project.Id);

            // Assert
            Assert.AreEqual(project, result);
        }

        [Test]
        public void Update_ShouldUpdateEntity()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };
            _context.Set<Project>().Add(project);
            _context.SaveChanges();

            project.Title = "Updated Project";

            // Act
            var result = _repository.Update(project);

            // Assert
            Assert.AreEqual(project, result);
            Assert.AreEqual("Updated Project", _context.Set<Project>().Find(project.Id).Title);
        }

        [Test]
        public void EntityExists_ShouldReturnTrue_WhenEntityExists()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };
            _context.Set<Project>().Add(project);
            _context.SaveChanges();

            // Act
            var result = _repository.EntityExists(project.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EntityExists_ShouldReturnFalse_WhenEntityDoesNotExist()
        {
            // Act
            var result = _repository.EntityExists(1);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Detach_ShouldDetachEntity()
        {
            // Arrange
            var project = new Project { Id = 1, Title = "Test Project" };
            _context.Set<Project>().Add(project);
            _context.SaveChanges();

            // Act
            _repository.Detach(project);

            // Assert
            var entry = _context.Entry(project);
            Assert.AreEqual(EntityState.Detached, entry.State);
        }

        [Test]
        public void DeleteFromLikedComments_ShouldRemoveLikedComment()
        {
            // Arrange
            var likedComment = new LikedComments { CommentId = 1, UserId = 1 };
            _context.LikedComments.Add(likedComment);
            _context.SaveChanges();

            // Act
            _repository.DeleteFromLikedComments(1, 1);

            // Assert
            Assert.AreEqual(0, _context.LikedComments.Count());
        }
    }
}

