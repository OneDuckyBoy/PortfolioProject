////using Moq;
////using NUnit.Framework;
////using CloudinaryDotNet;
////using CloudinaryDotNet.Actions;
////using Core.Services;
////using Microsoft.AspNetCore.Http;
////using System;
////using System.IO;
////using System.Net;
////using System.Threading.Tasks;

////namespace ProjectTests.Services
////{
////    public class ImageUploadServiceTest
////    {
////        private Mock<Cloudinary> _mockCloudinary;
////        private ImageUploadService _imageUploadService;
////        private Mock<IFormFile> _mockFormFile;

////        [SetUp]
////        public void Setup()
////        {
////            _mockCloudinary = new Mock<Cloudinary>(MockBehavior.Strict);
////            _imageUploadService = new ImageUploadService(_mockCloudinary.Object);
////            _mockFormFile = new Mock<IFormFile>();
////        }

////        [Test]
////        public async Task UploadImageAsync_SuccessfulUpload_ReturnsSecureUrl()
////        {
////            // Arrange
////            var fileName = "test-image.jpg";
////            var secureUrl = "https://res.cloudinary.com/test/image/upload/test-image.jpg";
////            var memoryStream = new MemoryStream();

////            _mockFormFile.Setup(f => f.FileName).Returns(fileName);
////            _mockFormFile.Setup(f => f.OpenReadStream()).Returns(memoryStream);

////            var uploadResult = new ImageUploadResult
////            {
////                StatusCode = HttpStatusCode.OK,
////                SecureUrl = new Uri(secureUrl)
////            };

////            _mockCloudinary
////                .Setup(c => c.UploadAsync(It.IsAny<ImageUploadParams>()))
////                .ReturnsAsync(uploadResult);

////            // Act
////            var result = await _imageUploadService.UploadImageAsync(_mockFormFile.Object);

////            // Assert
////            Assert.AreEqual(secureUrl, result);
////            _mockCloudinary.Verify(c => c.UploadAsync(It.IsAny<ImageUploadParams>()), Times.Once);
////        }

////        [Test]
////        public void UploadImageAsync_FailedUpload_ThrowsException()
////        {
////            // Arrange
////            var fileName = "test-image.jpg";
////            var errorMessage = "Upload failed";
////            var memoryStream = new MemoryStream();

////            _mockFormFile.Setup(f => f.FileName).Returns(fileName);
////            _mockFormFile.Setup(f => f.OpenReadStream()).Returns(memoryStream);

////            var uploadResult = new ImageUploadResult
////            {
////                StatusCode = HttpStatusCode.BadRequest,
////                Error = new Error { Message = errorMessage }
////            };

////            _mockCloudinary
////                .Setup(c => c.UploadAsync(It.IsAny<ImageUploadParams>()))
////                .ReturnsAsync(uploadResult);

////            // Act & Assert
////            var exception = Assert.ThrowsAsync<Exception>(async () =>
////                await _imageUploadService.UploadImageAsync(_mockFormFile.Object));

////            Assert.That(exception.Message, Is.EqualTo($"Image upload failed: {errorMessage}"));
////            _mockCloudinary.Verify(c => c.UploadAsync(It.IsAny<ImageUploadParams>()), Times.Once);
////        }

////        [Test]
////        public async Task DeleteImageAsync_SuccessfulDeletion_CompletesWithoutException()
////        {
////            // Arrange
////            var publicId = "test_public_id";
////            var deleteResult = new DeletionResult
////            {
////                StatusCode = HttpStatusCode.OK
////            };

////            _mockCloudinary
////                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
////                .ReturnsAsync(deleteResult);

////            // Act & Assert
////            await _imageUploadService.DeleteImageAsync(publicId);

////            _mockCloudinary.Verify(c => c.DestroyAsync(It.Is<DeletionParams>(p => p.PublicId == publicId)), Times.Once);
////        }

////        [Test]
////        public void DeleteImageAsync_FailedDeletion_ThrowsException()
////        {
////            // Arrange
////            var publicId = "test_public_id";
////            var errorMessage = "Deletion failed";
////            var deleteResult = new DeletionResult
////            {
////                StatusCode = HttpStatusCode.BadRequest,
////                Error = new Error { Message = errorMessage }
////            };

////            _mockCloudinary
////                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
////                .ReturnsAsync(deleteResult);

////            // Act & Assert
////            var exception = Assert.ThrowsAsync<Exception>(async () =>
////                await _imageUploadService.DeleteImageAsync(publicId));

////            Assert.That(exception.Message, Is.EqualTo($"Image deletion failed: {errorMessage}"));
////            _mockCloudinary.Verify(c => c.DestroyAsync(It.Is<DeletionParams>(p => p.PublicId == publicId)), Times.Once);
////        }
////    }
////}
//using Moq;
//using NUnit.Framework;
//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;
//using Core.Services;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.IO;
//using System.Net;
//using System.Threading.Tasks;
//using System.Threading;

//namespace ProjectTests.Services
//{
//    public class ImageUploadServiceTest
//    {
//        private Mock<Cloudinary> _mockCloudinary;
//        private ImageUploadService _imageUploadService;
//        private Mock<IFormFile> _mockFormFile;

//        [SetUp]
//        public void Setup()
//        {
//            // Using a proxy approach to solve the optional parameters issue
//            _mockCloudinary = MockCloudinary.Create();
//            _imageUploadService = new ImageUploadService(_mockCloudinary.Object);
//            _mockFormFile = new Mock<IFormFile>();
//        }

//        [Test]
//        public async Task UploadImageAsync_SuccessfulUpload_ReturnsSecureUrl()
//        {
//            // Arrange
//            var fileName = "test-image.jpg";
//            var secureUrl = "https://res.cloudinary.com/test/image/upload/test-image.jpg";
//            var memoryStream = new MemoryStream();

//            _mockFormFile.Setup(f => f.FileName).Returns(fileName);
//            _mockFormFile.Setup(f => f.OpenReadStream()).Returns(memoryStream);

//            var uploadResult = new ImageUploadResult
//            {
//                StatusCode = HttpStatusCode.OK,
//                SecureUrl = new Uri(secureUrl)
//            };

//            // Setup using our helper method instead of direct Setup
//            MockCloudinary.SetupUploadAsync(_mockCloudinary, uploadResult);

//            // Act
//            var result = await _imageUploadService.UploadImageAsync(_mockFormFile.Object);

//            // Assert
//            Assert.AreEqual(secureUrl, result);
//            MockCloudinary.VerifyUploadAsync(_mockCloudinary, Times.Once());
//        }

//        [Test]
//        public void UploadImageAsync_FailedUpload_ThrowsException()
//        {
//            // Arrange
//            var fileName = "test-image.jpg";
//            var errorMessage = "Upload failed";
//            var memoryStream = new MemoryStream();

//            _mockFormFile.Setup(f => f.FileName).Returns(fileName);
//            _mockFormFile.Setup(f => f.OpenReadStream()).Returns(memoryStream);

//            var uploadResult = new ImageUploadResult
//            {
//                StatusCode = HttpStatusCode.BadRequest,
//                Error = new Error { Message = errorMessage }
//            };

//            MockCloudinary.SetupUploadAsync(_mockCloudinary, uploadResult);

//            // Act & Assert
//            var exception = Assert.ThrowsAsync<Exception>(async () =>
//                await _imageUploadService.UploadImageAsync(_mockFormFile.Object));

//            Assert.That(exception.Message, Is.EqualTo($"Image upload failed: {errorMessage}"));
//            MockCloudinary.VerifyUploadAsync(_mockCloudinary, Times.Once());
//        }

//        [Test]
//        public async Task DeleteImageAsync_SuccessfulDeletion_CompletesWithoutException()
//        {
//            // Arrange
//            var publicId = "test_public_id";
//            var deleteResult = new DeletionResult
//            {
//                StatusCode = HttpStatusCode.OK
//            };

//            MockCloudinary.SetupDestroyAsync(_mockCloudinary, deleteResult);

//            // Act & Assert
//            await _imageUploadService.DeleteImageAsync(publicId);

//            MockCloudinary.VerifyDestroyAsync(_mockCloudinary, publicId, Times.Once());
//        }

//        [Test]
//        public void DeleteImageAsync_FailedDeletion_ThrowsException()
//        {
//            // Arrange
//            var publicId = "test_public_id";
//            var errorMessage = "Deletion failed";
//            var deleteResult = new DeletionResult
//            {
//                StatusCode = HttpStatusCode.BadRequest,
//                Error = new Error { Message = errorMessage }
//            };

//            MockCloudinary.SetupDestroyAsync(_mockCloudinary, deleteResult);

//            // Act & Assert
//            var exception = Assert.ThrowsAsync<Exception>(async () =>
//                await _imageUploadService.DeleteImageAsync(publicId));

//            Assert.That(exception.Message, Is.EqualTo($"Image deletion failed: {errorMessage}"));
//            MockCloudinary.VerifyDestroyAsync(_mockCloudinary, publicId, Times.Once());
//        }
//    }

//    // Helper class to work around the optional parameters issue
//    public static class MockCloudinary
//    {
//        // Create a properly configured mock
//        public static Mock<Cloudinary> Create()
//        {
//            var mockCloudinary = new Mock<Cloudinary>(MockBehavior.Strict, new Account("dummy", "dummy", "dummy"));
//            return mockCloudinary;
//        }

//        // Setup method for UploadAsync that avoids the expression tree issue
//        public static void SetupUploadAsync(Mock<Cloudinary> mockCloudinary, ImageUploadResult result)
//        {
//            // Use proper signature with CancellationToken
//            mockCloudinary
//                .Setup(c => c.UploadAsync(It.IsAny<ImageUploadParams>(), It.IsAny<CancellationToken?>()))
//                .ReturnsAsync(result);
//        }

//        // Verify method for UploadAsync
//        public static void VerifyUploadAsync(Mock<Cloudinary> mockCloudinary, Times times)
//        {
//            mockCloudinary.Verify(c => c.UploadAsync(It.IsAny<ImageUploadParams>(), It.IsAny<CancellationToken?>()), times);
//        }

//        // Setup method for DestroyAsync that avoids the expression tree issue
//        public static void SetupDestroyAsync(Mock<Cloudinary> mockCloudinary, DeletionResult result)
//        {
//            // DestroyAsync takes only one parameter in newer versions
//            mockCloudinary
//                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
//                .ReturnsAsync(result);
//        }

//        // Verify method for DestroyAsync
//        public static void VerifyDestroyAsync(Mock<Cloudinary> mockCloudinary, string publicId, Times times)
//        {
//            mockCloudinary.Verify(c => c.DestroyAsync(It.Is<DeletionParams>(p => p.PublicId == publicId)), times);
//        }
//    }
//}