using Core.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class EmailSenderTest
    {
        private IEmailSender _emailSender;

        [SetUp]
        public void Setup()
        {
            _emailSender = new EmailSender();
        }

        [Test]
        public async Task SendEmailAsync_ShouldCompleteSuccessfully()
        {
            // Arrange
            var email = "test@example.com";
            var subject = "Test Subject";
            var htmlMessage = "<p>This is a test message.</p>";

            // Act
            await _emailSender.SendEmailAsync(email, subject, htmlMessage);

            // Assert
            Assert.Pass("SendEmailAsync completed successfully.");
        }
    }
}