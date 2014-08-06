using Xunit;

namespace MvcApplication2.Tests.Controllers
{
    using Moq;

    using MvcApplication2.Controllers;
    using MvcApplication2.Database.Repositories.Interfaces;
    using System.Web.Mvc;

    public class CategoryControllerTest
    {
        public CategoryControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [Fact]
        public void Category_ConstructorAcceptsUnitOfWork()
        {
            // Arrange
            var unitOfWorkStub = Mock.Of<IUnitOfWork>();
            var result = new CategoryController(unitOfWorkStub);
        }

        [Fact]
        public void Category_ExecuteIndexAction_ReturnsIndexView()
        {
            // Arrange
            var unitOfWorkStub = Mock.Of<IUnitOfWork>();

            // Act
            var result = new CategoryController(unitOfWorkStub).Index() as ViewResult;

            // Assert
            Assert.Equal("Index", result.ViewName);
        }
    }
}
