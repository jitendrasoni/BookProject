using Microsoft.AspNetCore.Mvc;
using MyBookLibrary.Models;
using MyBookLibrary.Repositories;

namespace MyBookLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {

            var books = _bookRepository.GetAll();
            return View(books);
        }

        public IActionResult Create()
        {
            var model = new Book(); // Create a new instance of Book
            return View(model); // Pass the model to the view
        }

        [HttpPost]
        public IActionResult Create(Book? book)
        {
            _bookRepository.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _bookRepository.Update(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}