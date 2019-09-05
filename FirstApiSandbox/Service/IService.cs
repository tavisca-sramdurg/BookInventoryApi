using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;

namespace FirstApiSandbox.Service
{
    public interface IService
    {
        List<Book> GetBooksfromService();
        Book GetBooksFromDatabaseAtIndex(int id);
        void AddBookUsingService(Book newBook);
        bool UpdateBookUsingService(int id, Book newBook);
        bool DeleteBookUsingService(int id);
    }
}
