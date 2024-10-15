using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using TheBattleLibrary.API.Middlewares;

namespace TheBattleLibrary.API.Tests.Middlewares
{
    public class ExceptionHandlingMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_UnhandledException_ReturnsInternalServerError()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ExceptionHandlingMiddleware>>();

            // Mock the next middleware to throw an unhandled exception
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(rd => rd(It.IsAny<HttpContext>()))
                .ThrowsAsync(new Exception("Test exception"));

            var middleware = new ExceptionHandlingMiddleware(requestDelegateMock.Object, loggerMock.Object);

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream(); // Use MemoryStream to capture the response

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin); // Reset the stream position to read from it

            using (var reader = new StreamReader(context.Response.Body))
            {
                var responseBody = await reader.ReadToEndAsync();
                Assert.Contains("Test exception", responseBody);
            }

            // Verify that the logger was called
            loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Unhandled exception occurred")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}