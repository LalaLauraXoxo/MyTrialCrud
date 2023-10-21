using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IBookService
    {
        public void AddBook(BookViewModel bookViewModel);

        public List<Book> GetBooks();

        public Book GetBook(int id);

        public bool UpdateBook(BookViewModel bookViewModel);
        public bool DeleteBook(BookViewModel bookViewModel);
    }
}
