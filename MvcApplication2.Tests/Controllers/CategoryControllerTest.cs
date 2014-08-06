using Xunit;

namespace MvcApplication2.Tests.Controllers
{
    using Moq;

    using MvcApplication2.Controllers;
    using MvcApplication2.Models;
    using MvcApplication2.Database.Repositories.Interfaces;
    using System.Web.Mvc;

    public class CategoryControllerTest
    {
        private readonly IUnitOfWork UnitOfWorkStub;

        public CategoryControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
            UnitOfWorkStub = Mock.Of<IUnitOfWork>();
        }

        [Fact]
        public void Category_ConstructorAcceptsUnitOfWork()
        {
            var result = new CategoryController(this.UnitOfWorkStub);
        }

        [Fact]
        public void Category_ExecuteIndexAction_ReturnsIndexView()
        {
            // Act
            var result = new CategoryController(this.UnitOfWorkStub).Index() as ViewResult;

            // Assert
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void Category_ExecuteIndexAction_ViewContainsCategoryIndexViewModel()
        {
            // Act
            var result = new CategoryController(this.UnitOfWorkStub).Index() as ViewResult;
            var model = result.Model;

            // Assert
            Assert.IsType<CategoryIndexViewModel>(model);
        }
    }
}
