namespace MvcApplication2.Tests.Controllers
{
    using System.Linq;

    using Moq;

    using MvcApplication2.App_Start;
    using MvcApplication2.Controllers;
    using Entities = MvcApplication2.Database.Entities;
    using MvcApplication2.Models;
    using MvcApplication2.Database.Repositories.Interfaces;
    using System.Web.Mvc;

    using NUnit.Framework;

    using MvcApplication2.Tests.Database.Repositories;

    public class CategoryControllerTest
    {
        private IUnitOfWork UnitOfWorkMock;

        [SetUp]
        public void CategoryControllerTest_SetUp()
        {
            AutomapperConfig.Register();

            var categoryRepository = new MemoryRepository<Entities.Category>();
            categoryRepository.Insert(new Entities.Category() { Id = 1, Name = "Category 1" });
            categoryRepository.Insert(new Entities.Category() { Id = 2, Name = "Category 2" });

            this.UnitOfWorkMock = Mock.Of<IUnitOfWork>(m => m.CategoryRepository.GetAll() == categoryRepository.GetAll());
        }

        [Test]
        public void Category_ConstructorAcceptsUnitOfWork()
        {
            var result = new CategoryController(this.UnitOfWorkMock);
        }

        [Test]
        public void Category_ExecuteIndexAction_ReturnsIndexView()
        {
            // Act
            var result = new CategoryController(this.UnitOfWorkMock).Index() as ViewResult;

            // Assert
            Assert.That(result.ViewName, Is.EqualTo("Index").IgnoreCase);
        }

        [Test]
        public void Category_ExecuteIndexAction_ViewContainsCategoryIndexViewModel()
        {
            // Act
            var result = new CategoryController(this.UnitOfWorkMock).Index() as ViewResult;
            var model = result.Model;

            // Assert
            Assert.That(model, Is.TypeOf<CategoryIndexViewModel>());
        }

        [Test]
        public void Category_ExecuteIndexAction_CallsGetAllMethod()
        {
            // Act
            var result = new CategoryController(UnitOfWorkMock).Index();

            // Assert
            Mock.Get(UnitOfWorkMock).Verify(m => m.CategoryRepository.GetAll(), Times.Once);
        }

        [Test]
        public void Repository_GetAll_ReturnsCorrectCountValue()
        {
            // Arrange
            var categoryRepository = new MemoryRepository<Entities.Category>();
            categoryRepository.Insert(new Entities.Category() { Id = 1, Name = "Category 1" });
            categoryRepository.Insert(new Entities.Category() { Id = 2, Name = "Category 2" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.CategoryRepository).Returns(categoryRepository);

            // Act
            var numberOfItems = unitOfWorkMock.Object.CategoryRepository.GetAll().Count();

            // Assert
            Assert.That(numberOfItems, Is.EqualTo(2));
        }
    }
}
