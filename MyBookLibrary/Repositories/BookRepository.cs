using MyBookLibrary.Models;
using MyBookLibrary.Services;
using Newtonsoft.Json;

namespace MyBookLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;
        private readonly DataSettings _dataSettings;
        private readonly ILogger<BookService> _logger;

        public BookRepository(ILogger<BookService> logger, DataSettings dataSettings)
        {
            _logger = logger;
            _dataSettings = dataSettings;
            _books = LoadBooksFromDataFile();
        }

        private List<Book> LoadBooksFromDataFile()
        {
            try
            {
                _logger.LogInformation("LoadBooksFromDataFile executed");
                string? filePath = _dataSettings.FilePath;
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();
                }
                return new List<Book>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading data from file.");
                throw;
            }


        }

        private void SaveBooksToDataFile()
        {

            try
            {
                _logger.LogInformation("SaveBooksToDataFile executed");
                string jsonData = JsonConvert.SerializeObject(_books);
                string? filePath = _dataSettings.FilePath;
                if (filePath != null) File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving data from file.");
                throw;
            }
        }

        public void Add(Book? book)
        {
            if (book != null)
            {
                book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(book);
            }

            SaveBooksToDataFile(); // Save changes to file
        }

        public IEnumerable<Book?> GetAll()
        {
            return _books;
        }

        public Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
                SaveBooksToDataFile(); // Save changes to file
            }
        }

        public void Delete(int id)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                SaveBooksToDataFile(); // Save changes to file
            }
        }
    }
}
