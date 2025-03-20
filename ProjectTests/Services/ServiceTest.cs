using Core.Repositories;
using Core.Services;
using Models.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ProjectTests
{
    public class ServiceTest
    {
        private Mock<IRepository<BaseEntity>> _repositoryMock;
        private Service<BaseEntity> _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<BaseEntity>>();
            _service = new Service<BaseEntity>(_repositoryMock.Object);
        }

        [Test]
        public void Add_ShouldCallRepositoryAdd()
        {
            var entity = new BaseEntity { Id = 1 };
            _repositoryMock.Setup(r => r.Add(entity)).Returns(entity);

            var result = _service.Add(entity);

            _repositoryMock.Verify(r => r.Add(entity), Times.Once);
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void EntityExists_ShouldReturnTrue_WhenEntityExists()
        {
            _repositoryMock.Setup(r => r.EntityExists(1)).Returns(true);

            var result = _service.EntityExists(1);

            _repositoryMock.Verify(r => r.EntityExists(1), Times.Once);
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_ShouldCallRepositoryDelete()
        {
            _service.Delete(1);

            _repositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAllEntities()
        {
            var entities = new List<BaseEntity> { new BaseEntity { Id = 1 } };
            _repositoryMock.Setup(r => r.GetAll()).Returns(entities);

            var result = _service.GetAll();

            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
            Assert.AreEqual(entities, result);
        }

        [Test]
        public void GetById_ShouldReturnEntity()
        {
            var entity = new BaseEntity { Id = 1 };
            _repositoryMock.Setup(r => r.GetById(1)).Returns(entity);

            var result = _service.GetById(1);

            _repositoryMock.Verify(r => r.GetById(1), Times.Once);
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void Update_ShouldCallRepositoryUpdate()
        {
            var entity = new BaseEntity { Id = 1 };
            _repositoryMock.Setup(r => r.Update(entity)).Returns(entity);

            var result = _service.Update(entity);

            _repositoryMock.Verify(r => r.Update(entity), Times.Once);
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void Detach_ShouldCallRepositoryDetach()
        {
            var entity = new BaseEntity { Id = 1 };
            _service.Detach(entity);

            _repositoryMock.Verify(r => r.Detach(entity), Times.Once);
        }

        [Test]
        public void DeleteFromLikedComments_ShouldCallRepositoryDeleteFromLikedComments()
        {
            _service.DeleteFromLikedComments(1, 1);

            _repositoryMock.Verify(r => r.DeleteFromLikedComments(1, 1), Times.Once);
        }
    }
}
