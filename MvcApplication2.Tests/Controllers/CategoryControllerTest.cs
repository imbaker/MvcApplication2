using Xunit;

namespace MvcApplication2.Tests.Controllers
{
    using System.Linq;

    using Moq;
    using MvcApplication2.Controllers;
    using Entities = MvcApplication2.Database.Entities;
    using MvcApplication2.Models;
    using MvcApplication2.Database.Repositories.Interfaces;
    using System.Web.Mvc;

    using MvcApplication2.Tests.Database.Repositories;

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

        [Fact]
        public void Category_ExecuteIndexAction_CallsGetAllMethod()
        {
            // Arrange
            var categoryRepository = new MemoryRepository<Entities.Category>();
            categoryRepository.Insert(new Entities.Category() { Id = 1, Name = "Category 1" });
            categoryRepository.Insert(new Entities.Category() { Id = 2, Name = "Category 2" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.CategoryRepository.GetAll()).Returns(categoryRepository.GetAll());

            // Act
            var result = new CategoryController(unitOfWorkMock.Object).Index();

            // Assert
            unitOfWorkMock.Verify(m => m.CategoryRepository.GetAll(), Times.Once);
        }

        [Fact]
        public void Repository_GetAll_ReturnsCorrectCountValue()
        {
            // Arrange
            var categoryRepository = new MemoryRepository<Entities.Category>();
            categoryRepository.Insert(new Entities.Category() { Id = 1, Name = "Category 1" });
            categoryRepository.Insert(new Entities.Category() { Id = 2, Name = "Category 2" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.CategoryRepository).Returns(categoryRepository);

            // Act
            var result = unitOfWorkMock.Object.CategoryRepository.GetAll().Count();

            // Assert
            Assert.Equal(2, result);
        }
    }
}
