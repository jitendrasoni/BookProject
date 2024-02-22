using MyBookLibrary.Models;
using Newtonsoft.Json;

namespace MyBookLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;
        private readonly DataSettings _dataSettings;

        public BookRepository(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
            _books = LoadBooksFromDataFile();
        }

        private List<Book> LoadBooksFromDataFile()
        {
            string? filePath = _dataSettings.FilePath;
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();
            }
            return new List<Book>();
        }

        private void SaveBooksToDataFile()
        {
            string jsonData = JsonConvert.SerializeObject(_books);
            string? filePath = _dataSettings.FilePath;
            if (filePath != null) File.WriteAllText(filePath, jsonData);
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
