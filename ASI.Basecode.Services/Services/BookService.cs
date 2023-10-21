using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using Hangfire.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(BookViewModel bookViewModel)
        {
            Book book = new()
            {
                Author = bookViewModel.Author,
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                CreatedBy = "Clarisse Yvonne B. Jacalan",
                CreatedDate = DateTime.Now,
                UpdatedBy = "Clarisse Yvonne B. Jacalan",
                UpdatedTime = DateTime.Now,
            };

            _bookRepository.AddBook(book);
        }

        public List<Book> GetBooks()
        {
            var books= _bookRepository.GetBooks();
            return books;
        }

        public Book GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);

            return book;
        }
        public bool UpdateBook(BookViewModel bookViewModel)
        {
            Book book = _bookRepository.GetBook(bookViewModel.Id);
            if (book != null)
            {
                book.Title = bookViewModel.Title;
                book.Author = bookViewModel.Author;
                book.Description = bookViewModel.Description;
                book.UpdatedBy = "hanphil";
                book.UpdatedTime = System.DateTime.Now;

                _bookRepository.UpdateBook(book);
                return true;
            }

            return false;
        }
        public bool DeleteBook(BookViewModel bookViewModel)
        {
            Book book = _bookRepository.GetBook(bookViewModel.Id);
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
                return true;
            }

            return false;
        }
    }
}
