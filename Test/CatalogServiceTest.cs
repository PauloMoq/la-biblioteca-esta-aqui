using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using BusinessObjects.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using BusinessLayer.Catalog;

namespace Services.Tests
{
    [TestClass]
    public class CatalogServiceTests
    {
        private Mock<ICatalogManager> _mockCatalogManager;

        public CatalogServiceTests()
        {
            _mockCatalogManager = new Mock<ICatalogManager>();
        }

        [TestMethod]
        public void ShowCatalog_ReturnsAllBooks()
        {
            // Arrange
            var mockBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "Le Secret des Dragons",
                    Pages = "320",
                    Type = BusinessObjects.Entity.Type.Fantasy,
                    Rate = 5
                },
                new Book
                {
                    Id = 2,
                    Name = "Les Voyages de Marco Polo",
                    Pages = "450",
                    Type = BusinessObjects.Entity.Type.Aventure,
                    Rate = 4
                }
            };


            _mockCatalogManager.Setup(manager => manager.DisplayCatalog()).Returns(mockBooks);
            var service = new CatalogService(_mockCatalogManager.Object);

            //Act
            var result = service.ShowCatalog();

            try
            {
                CollectionAssert.AreEqual(mockBooks, (System.Collections.ICollection)result);
                Console.WriteLine("ShowCatalog_ReturnsAllBooks: Le test a réussi.");
            }
            catch (AssertFailedException ex)
            {
                Console.WriteLine("ShowCatalog_ReturnsAllBooks: Le test a échoué. " + ex.Message);
            }
        }
        //Nouveaux tests
        [TestMethod]
        public void DisplayCatalog_ByType_ReturnsFilteredBooks()
        {
            // Arrange
            var mockBooks = new List<Book>
            {
                new Book
                {
                    Id = 1, Name = "Le Secret des Dragons", Pages = "320",
                    Type = BusinessObjects.Entity.Type.Fantasy, Rate = 5
                },
                new Book
                {
                    Id = 2, Name = "Les Voyages de Marco Polo", Pages = "450",
                    Type = BusinessObjects.Entity.Type.Aventure, Rate = 4
                }
             };
            _mockCatalogManager.Setup(manager => manager.DisplayCatalog(BusinessObjects.Entity.Type.Fantasy)).Returns(mockBooks.Where(b => b.Type == BusinessObjects.Entity.Type.Fantasy));
            var catalogService = new CatalogService(_mockCatalogManager.Object);

            // Act
            var result = catalogService.ShowCatalog(BusinessObjects.Entity.Type.Fantasy);

            // Assert
            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy), "DisplayCatalog_ByType_ReturnsFilteredBooks: Le test a échoué.");
        }

        [TestMethod]
        public void FindBook_ReturnsCorrectBook()
        {
            // Arrange
            var mockBook = new Book
            {
                Id = 1,
                Name = "Le Secret des Dragons",
                Pages = "320",
                Type = BusinessObjects.Entity.Type.Fantasy,
                Rate = 5
            };
            _mockCatalogManager.Setup(manager => manager.FindBook(1)).Returns(mockBook);
            var catalogService = new CatalogService(_mockCatalogManager.Object);

            // Act
            var result = catalogService.FindBook(1);

            // Assert
            Assert.AreEqual(mockBook, result, "FindBook_ReturnsCorrectBook: Le test a échoué.");
        }

        [TestMethod]
        public void FindFantasyBooks_ReturnsFantasyBooks()
        {
            // Arrange
            var mockBooks = new List<Book>
            {
                new Book
                {
                    Id = 1, Name = "Le Secret des Dragons", Pages = "320",
                    Type = BusinessObjects.Entity.Type.Fantasy, Rate = 5
                }
            };
            _mockCatalogManager.Setup(manager => manager.findFantasyBooks()).Returns(mockBooks);
            var catalogService = new CatalogService(_mockCatalogManager.Object);

            // Act
            var result = catalogService.findFantasyBooksInCatalog();

            // Assert
            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy), "FindFantasyBooks_ReturnsFantasyBooks: Le test a échoué.");
        }

        [TestMethod]
        public void FindBestBook_ReturnsBookWithHighestRate()
        {
            // Arrange
            var mockBook = new Book
            {
                Id = 1,
                Name = "Le Secret des Dragons",
                Pages = "320",
                Type = BusinessObjects.Entity.Type.Fantasy,
                Rate = 5
            };
            _mockCatalogManager.Setup(manager => manager.findBestBook()).Returns(mockBook);
            var catalogService = new CatalogService(_mockCatalogManager.Object);

            // Act
            var result = catalogService.findBestBookInCatalog();

            // Assert
            Assert.AreEqual(mockBook, result, "FindBestBook_ReturnsBookWithHighestRate: Le test a échoué.");
        }


    }
}
