using Roman.AppConfig.Domain.Model;

namespace Roman.AppConfig.Tests
{
    public class ApplicationRegistrationTests
    {
        [Fact]
        public void ApplicationRegistration_Creation_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var application = new ApplicationRegistration(id, "test");

            // Act
            application.Description = "test";
            // Assert

            application.Name.Should().Be("test");
            application.Id.Should().Be(id);
            application.CreateDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1000));
            application.Description.Should().Be("test");
        }
    }
}