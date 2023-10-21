using ASI.Basecode.Data.Models;
using ASI.Basecode.Data;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookService.AddBook(bookViewModel);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBook(id);
            if (book != null)
            {
                BookViewModel bookViewModel = new()
                {
                    Id = id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                };

                return View(bookViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(BookViewModel bookViewModel)
        {
            bool isDeleted = _bookService.DeleteBook(bookViewModel);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
