using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;

namespace FirstApiSandbox.Service
{
    public class BookService : IService
    {
        BookData bookData = new BookData();

        public List<Book> GetBooksfromService()
        {
            return bookData.GetBooksFromDatabase();
        }

        public Book GetBookFromServiceByName(string name)
        {
            return bookData.GetBooksFromDatabaseAtIndex(name);
        }

        public void AddBookUsingService(Book newBook)
        {
            BookData.bookList.Add(newBook);
        }

        public bool UpdateBookUsingService(string name, Book newBook)
        {
            if (name == "")
                return false;
            return bookData.UpdateBookInDatabase(name, newBook);
        }

        public bool DeleteBookUsingService(string name)
        {
            if (name == "")
                return false;
            return bookData.DeleteBookFromDatabase(name);
        }

    }
}
