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


        public void AddBookUsingService(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookUsingService(int id, Book newBook)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookUsingService(int id)
        {
            throw new NotImplementedException();
        }

    }
}
