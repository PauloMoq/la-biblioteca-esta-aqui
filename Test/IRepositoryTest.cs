using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataAccessLayer.Repository;
using BusinessObjects.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Tests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private Mock<IRepository<Book>> _mockRepository;

        public BookRepositoryTests()
        {
            _mockRepository = new Mock<IRepository<Book>>();
        }

        [TestMethod]
        public void GetAll_ReturnsAllBooks()
        {
            // Arrange
            var mockBooks = new List<Book>
            {
                new Book { Id = 1, Name = "Le Secret des Dragons", Pages = "320", Type = BusinessObjects.Entity.Type.Fantasy, Rate = 5 },
                new Book { Id = 2, Name = "Les Voyages de Marco Polo", Pages = "450", Type = BusinessObjects.Entity.Type.Aventure, Rate = 4 }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(mockBooks);

            // Act
            var result = _mockRepository.Object.GetAll();

            // Assert
            Assert.AreEqual(mockBooks.Count, result.Count(), "GetAll_ReturnsAllBooks: Le test a échoué.");
            CollectionAssert.AreEquivalent(mockBooks, result.ToList(), "GetAll_ReturnsAllBooks: Les collections ne correspondent pas.");
        }

        [TestMethod]
        public void Get_ReturnsCorrectBook()
        {
            // Arrange
            var mockBook = new Book { Id = 1, Name = "Le Secret des Dragons", Pages = "320", Type = BusinessObjects.Entity.Type.Fantasy, Rate = 5 };
            _mockRepository.Setup(repo => repo.Get(1)).Returns(mockBook);

            // Act
            var result = _mockRepository.Object.Get(1);

            // Assert
            Assert.AreEqual(mockBook, result, "Get_ReturnsCorrectBook: Le test a échoué.");
        }

    }
}
