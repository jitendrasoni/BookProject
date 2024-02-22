using Microsoft.Extensions.Logging;
using MyBookLibrary.Models;
using MyBookLibrary.Repositories;

namespace MyBookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                _logger.LogInformation("Getting all books from the repository");
                return _bookRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all books");
                throw;
            }
            
        }

        public Book GetBookById(int id)
        {
            try
            {
                _logger.LogInformation("Getting book by ID {BookId} from the repository", id);
                return _bookRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting book by ID {BookId}", id);
                throw;
            }

        }

        public void AddBook(Book book)
        {
            try
            {
                _logger.LogInformation("Adding a new book: {@Book}", book);
                _bookRepository.Add(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new book: {@Book}", book);
                throw;
            }
      
        }

        public void UpdateBook(Book book)
        {
            try
            {
                _logger.LogInformation("Updating book with ID {BookId}: {@Book}", book.Id, book);
                _bookRepository.Update(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating book with ID {BookId}: {@Book}", book.Id, book);
                throw;
            }

          
        }

        public void DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation("Deleting book with ID {BookId}", id);
                _bookRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting book with ID {BookId}", id);
                throw;
            }
          
        }
        public IEnumerable<Book?> GetAll()
        {
            try
            {
                _logger.LogInformation("Get all Books");
                return _bookRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all books");
                throw;
            }

        }
    }
}
