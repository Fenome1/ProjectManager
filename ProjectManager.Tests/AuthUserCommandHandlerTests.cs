using Moq;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Features.Users.Handlers;
using ProjectManager.API.Models;
using Moq.EntityFrameworkCore;
using ProjectManager.API.Services;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class AuthUserCommandHandlerTests
    {
        [Test]
        public async Task AuthUserAsync_ValidRequest_ReturnsUser()
        {
            // Arrange
            var contextMock = new Mock<ProjectManagerDbContext>();
            var commandHandler = new AuthUserCommandHandler(contextMock.Object);

            var command = new AuthUserCommand
            {
                Login = "ValidLogin",
                Password = "ValidPassword"
            };

            var expectedUser = new User
            {
                Login = "ValidLogin",
                HashedPassword = HashService.HashPassword("ValidPassword"),
            };

            contextMock.Setup(c => c.Users)
                .ReturnsDbSet(new List<User>() { expectedUser });

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ValidLogin", result.Login);
        }
    }
}