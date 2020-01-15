using Moq;
using System;
using System.Collections.Generic;
using Xunit;
namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockRepo = new Mock<IDataRepository<Employee>>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(GetTestEmployees());
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Employee>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

    }
    private IEnumerable<Company> GetTestEmployees()
    {
        return new List<Employee>()
    {
        new Employee()
        {
            Id = 1,
            Name = "John"
        },
        new Employee()
        {
            Id = 2,
            Name = "Doe"
        }
    };
    }
}
