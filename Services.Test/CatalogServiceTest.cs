using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using BusinessObjects.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Services.Tests
{
    [TestClass]
    public class CatalogServiceTests
    {
        private Mock<ICatalogService> _mockCatalogService;

        public CatalogServiceTests()
        {
            _mockCatalogService = new Mock<ICatalogService>();
        }

        [TestMethod]
        public void ShowCatalog_ReturnsAllBooks()
        {
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
            _mockCatalogService.Setup(service => service.ShowCatalog()).Returns(mockBooks);

            var result = _mockCatalogService.Object.ShowCatalog();

            CollectionAssert.AreEqual(mockBooks, result.ToList());
        }

        [TestMethod]
        public void ShowCatalog_ByType_ReturnsFilteredBooks()
        {
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
            _mockCatalogService.Setup(service => service.ShowCatalog(BusinessObjects.Entity.Type.Fantasy)).Returns(mockBooks.Where(b => b.Type == BusinessObjects.Entity.Type.Fantasy));

            var result = _mockCatalogService.Object.ShowCatalog(BusinessObjects.Entity.Type.Fantasy);

            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy));
        }

        [TestMethod]
        public void FindBook_ReturnsCorrectBook()
        {
            var bookId = 1;
            var mockBook = new Book
                {
                    Id = 1,
                    Name = "Le Secret des Dragons",
                    Pages = "320",
                    Type = BusinessObjects.Entity.Type.Fantasy,
                    Rate = 5
                };
             
            _mockCatalogService.Setup(service => service.FindBook(bookId)).Returns(mockBook);

            var result = _mockCatalogService.Object.FindBook(bookId);

            Assert.AreEqual(mockBook, result);
        }

        [TestMethod]
        public void FindFantasyBooksInCatalog_ReturnsFantasyBooks()
        {
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
                    Type = BusinessObjects.Entity.Type.Fantasy,
                    Rate = 4
                }

            };
            _mockCatalogService.Setup(service => service.findFantasyBooksInCatalog()).Returns(mockBooks.Where(b => b.Type == BusinessObjects.Entity.Type.Fantasy));

            var result = _mockCatalogService.Object.findFantasyBooksInCatalog();

            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy));
        }

        [TestMethod]
        public void FindBestBookInCatalog_ReturnsBookWithHighestRate()
        {
            var mockBook = new Book
            {
                Id = 1,
                Name = "Le Secret des Dragons",
                Pages = "320",
                Type = BusinessObjects.Entity.Type.Fantasy,
                Rate = 10
            };
                
            _mockCatalogService.Setup(service => service.findBestBookInCatalog()).Returns(mockBook);

            var result = _mockCatalogService.Object.findBestBookInCatalog();

            Assert.AreEqual(mockBook, result);
        }
    }
}
