using Moq;
using Roman.AppConfig.Application.Queries;
using Roman.AppConfig.Domain.UnitOfWork;
using Roman.CQRS.Abstraction.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman.AppConfig.Tests.Application.Cqrs.Applications
{
    public class ApplicationListQueryTests
    {
        [Fact]
        public void ApplicationListQuery_Handler_Success()
        {
            // Arrange
            var query = new ApplicationListQuery();
            var queryModel = new Mock<IQueryDataModel>();

            var handler = new ApplicationListQueryHandler(queryModel.Object);
            // Act
            var result = handler.ExecuteAsync(query).Result;
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo(typeof(ISuccessResult<>));
        }
    }
}