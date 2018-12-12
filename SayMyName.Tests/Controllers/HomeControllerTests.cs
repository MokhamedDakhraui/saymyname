using Moq;
using NUnit.Framework;
using SayMyName.Contracts;
using SayMyName.Controllers;
using System;

namespace SayMyName.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<INameRepository> mockNameRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockNameRepository = this.mockRepository.Create<INameRepository>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Say_CanSayName_SaysTestName()
        {
            // Arrange
            this.mockNameRepository
                .Setup(repo => repo.GetName())
                .Returns("test_name");

            var homeController = new HomeController(
                this.mockNameRepository.Object);
            
            // Act
            var result = homeController.Say();

            // Assert
            Assert.AreEqual("test_name", homeController.ViewData["Name"]);
        }

        [Test]
        public void Say_CanSayName_SaysNoName()
        {
            // Arrange
            this.mockNameRepository
                .Setup(repo => repo.GetName())
                .Returns((string)null);

            var homeController = new HomeController(
                this.mockNameRepository.Object);

            // Act
            var result = homeController.Say();

            // Assert
            Assert.AreEqual("no name", homeController.ViewData["Name"]);
        }

        [Test]
        public void Set_ChangeName_SpecifiedName()
        {
            // Arrange
            string newName = "other_name";

            this.mockNameRepository
                .Setup(repo => repo.SetName(newName));

            var homeController = new HomeController(
                this.mockNameRepository.Object);

            // Act
            var result = homeController.Set(newName);

            // Assert
        }
    }
}
