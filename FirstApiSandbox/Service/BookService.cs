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

        public Book GetBooksFromDatabaseAtIndex(int id)
        {
            return bookData.GetBooksFromDatabaseAtIndex(id);
        }

        public void AddBookUsingService(Book newBook)
        {
            BookData.bookList.Add(newBook);
        }

        public bool UpdateBookUsingService(int id, Book newBook)
        {
            if (id < 0)
                return false;
            return bookData.UpdateBookInDatabase(id, newBook);
        }

        public bool DeleteBookUsingService(int id)
        {
            if (id < 0)
                return false;
            return bookData.DeleteBookFromDatabase(id);
        }

    }
}
