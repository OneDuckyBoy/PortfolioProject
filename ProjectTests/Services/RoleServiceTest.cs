using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace TestProject
{
//    public class RoleServiceTest
//    {
//        private Mock<IRoleRepository<IdentityRole<int>>> _repositoryMock;
//        private RoleService<IdentityRole<int>> _roleService;

//        [SetUp]
//        public void Setup()
//        {
//            _repositoryMock = new Mock<IRoleRepository<IdentityRole<int>>>();
//            _roleService = new RoleService<IdentityRole<int>>(_repositoryMock.Object);
//        }

//        [Test]
//        public void Add_ShouldCallRepositoryAdd()
//        {
//            var role = new IdentityRole<int> { Id = 1, Name = "Admin" };
//            _repositoryMock.Setup(r => r.Add(role)).Returns(role);

//            var result = _roleService.Add(role);

//            _repositoryMock.Verify(r => r.Add(role), Times.Once);
//            Assert.AreEqual(role, result);
//        }

//        [Test]
//        public void EntityExists_ShouldReturnTrue_WhenEntityExists()
//        {
//            _repositoryMock.Setup(r => r.EntityExists(1)).Returns(true);

//            var result = _roleService.EntityExists(1);

//            _repositoryMock.Verify(r => r.EntityExists(1), Times.Once);
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public void Delete_ShouldCallRepositoryDelete()
//        {
//            _roleService.Delete(1);

//            _repositoryMock.Verify(r => r.Delete(1), Times.Once);
//        }

//        [Test]
//        public void GetAll_ShouldReturnAllEntities()
//        {
//            var roles = new List<IdentityRole<int>> { new IdentityRole<int> { Id = 1, Name = "Admin" } };
//            _repositoryMock.Setup(r => r.GetAll()).Returns(roles);

//            var result = _roleService.GetAll();

//            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
//            Assert.AreEqual(roles, result);
//        }

//        [Test]
//        public void GetById_ShouldReturnEntity()
//        {
//            var role = new IdentityRole<int> { Id = 1, Name = "Admin" };
//            _repositoryMock.Setup(r => r.GetById(1)).Returns(role);

//            var result = _roleService.GetById(1);

//            _repositoryMock.Verify(r => r.GetById(1), Times.Once);
//            Assert.AreEqual(role, result);
//        }

//        [Test]
//        public void Update_ShouldCallRepositoryUpdate()
//        {
//            var role = new IdentityRole<int> { Id = 1, Name = "Admin" };
//            _repositoryMock.Setup(r => r.Update(role)).Returns(role);

//            var result = _roleService.Update(role);

//            _repositoryMock.Verify(r => r.Update(role), Times.Once);
//            Assert.AreEqual(role, result);
//        }
//    }
}
