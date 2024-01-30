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
                    id = 1,
                    name = "Le Secret des Dragons",
                    pages = "320",
                    type = Type.Fantasy,
                    rate = 5
                },
                new Book
                {
                    id = 2,
                    name = "Les Voyages de Marco Polo",
                    pages = "450",
                    type = Type.Aventure,
                    rate = 4
                }

            };
            _mockCatalogService.Setup(service => service.ShowCatalog()).Returns(mockBooks);

            var result = _mockCatalogService.Object.ShowCatalog();

            CollectionAssert.AreEqual(mockBooks, result.ToList());
        }

        [TestMethod]
        public void ShowCatalog_ByType_ReturnsFilteredBooks()
        {
            var mockBooks = new List<Book> { /* ajouter des livres fictifs ici, avec différents types */ };
            _mockCatalogService.Setup(service => service.ShowCatalog(BusinessObjects.Entity.Type.Fantasy)).Returns(mockBooks.Where(b => b.Type == BusinessObjects.Entity.Type.Fantasy));

            var result = _mockCatalogService.Object.ShowCatalog(BusinessObjects.Entity.Type.Fantasy);

            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy));
        }

        [TestMethod]
        public void FindBook_ReturnsCorrectBook()
        {
            var bookId = 1;
            var mockBook = new Book { /* initialiser avec id = 1 */ };
            _mockCatalogService.Setup(service => service.FindBook(bookId)).Returns(mockBook);

            var result = _mockCatalogService.Object.FindBook(bookId);

            Assert.AreEqual(mockBook, result);
        }

        [TestMethod]
        public void FindFantasyBooksInCatalog_ReturnsFantasyBooks()
        {
            var mockBooks = new List<Book> { /* ajouter des livres de fantasy ici */ };
            _mockCatalogService.Setup(service => service.findFantasyBooksInCatalog()).Returns(mockBooks.Where(b => b.Type == BusinessObjects.Entity.Type.Fantasy));

            var result = _mockCatalogService.Object.findFantasyBooksInCatalog();

            Assert.IsTrue(result.All(b => b.Type == BusinessObjects.Entity.Type.Fantasy));
        }

        [TestMethod]
        public void FindBestBookInCatalog_ReturnsBookWithHighestRate()
        {
            var mockBook = new Book { /* ajouter le livre avec la meilleure évaluation ici */ };
            _mockCatalogService.Setup(service => service.findBestBookInCatalog()).Returns(mockBook);

            var result = _mockCatalogService.Object.findBestBookInCatalog();

            Assert.AreEqual(mockBook, result);
        }
    }
}
