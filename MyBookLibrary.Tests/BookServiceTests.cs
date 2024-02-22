using Moq;
using MyBookLibrary.Models;
using Xunit;
using MyBookLibrary.Services;
using MyBookLibrary.Repositories;
using Microsoft.Extensions.Logging;

namespace MyBookLibrary.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var mockDataSettings = new Mock<DataSettings>();
            mockDataSettings.Setup(ds => ds.GetFilePath())
                            .Returns(Path.Combine(Environment.CurrentDirectory, "data/test", "books.json"));

            // Mocking the data in the repository
            var mockBooks = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Year = 2020 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Year = 2021 },
                new Book { Id = 3, Title = "Book 3", Author = "Author 3", Year = 2022 }
            };

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.GetAll()).Returns(mockBooks);

            var mockLogger = new Mock<ILogger<BookService>>();

            var bookService = new BookService(mockLogger.Object,mockBookRepository.Object);

            // Act
            var result = bookService.GetAll();

            // Assert
            Assert.Equal(mockBooks.Count, result?.Count());

            foreach (var mockBook in mockBooks)
            {
                var book = result?.FirstOrDefault(b => b.Id == mockBook.Id);
                Assert.NotNull(book);
                Assert.Equal(mockBook.Title, book.Title);
                Assert.Equal(mockBook.Author, book.Author);
                Assert.Equal(mockBook.Year, book.Year);
            }
        }
    }
}
