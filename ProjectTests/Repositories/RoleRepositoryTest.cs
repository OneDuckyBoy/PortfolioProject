using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using NUnit.Framework;
using Portfolio.Data;
using Portfolio.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTests
{
    public class RoleRepositoryTest
    {
        private ApplicationDbContext _context;
        private RoleRepository<Role> _roleRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _roleRepository = new RoleRepository<Role>(_context);
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
            var role = new Role { Id = 1, Name = "Admin" };

            // Act
            var result = _roleRepository.Add(role);

            // Assert
            Assert.AreEqual(role, result);
            Assert.AreEqual(1, _context.Roles.Count());
        }

        [Test]
        public void Delete_ShouldRemoveEntity()
        {
            // Arrange
            var role = new Role { Id = 1, Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act
            _roleRepository.Delete(role.Id);

            // Assert
            Assert.AreEqual(0, _context.Roles.Count());
        }

        [Test]
        public void GetAll_ShouldReturnAllEntities()
        {
            // Arrange
            var role1 = new Role { Id = 1, Name = "Admin" };
            var role2 = new Role { Id = 2, Name = "User" };
            _context.Roles.AddRange(role1, role2);
            _context.SaveChanges();

            // Act
            var result = _roleRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetById_ShouldReturnEntity()
        {
            // Arrange
            var role = new Role { Id = 1, Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act
            var result = _roleRepository.GetById(role.Id);

            // Assert
            Assert.AreEqual(role, result);
        }

        [Test]
        public void Update_ShouldUpdateEntity()
        {
            // Arrange
            var role = new Role { Id = 1, Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            role.Name = "SuperAdmin";

            // Act
            var result = _roleRepository.Update(role);

            // Assert
            Assert.AreEqual(role, result);
            Assert.AreEqual("SuperAdmin", _context.Roles.Find(role.Id).Name);
        }

        [Test]
        public void EntityExists_ShouldReturnTrue_WhenEntityExists()
        {
            // Arrange
            var role = new Role { Id = 1, Name = "Admin" };
            _context.Roles.Add(role);
            _context.SaveChanges();

            // Act
            var result = _roleRepository.EntityExists(role.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EntityExists_ShouldReturnFalse_WhenEntityDoesNotExist()
        {
            // Act
            var result = _roleRepository.EntityExists(1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

