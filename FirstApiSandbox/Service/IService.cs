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
        Book GetBookFromServiceByName(string name);
        void AddBookUsingService(Book newBook);
        bool UpdateBookUsingService(string name, Book newBook);
        bool DeleteBookUsingService(string name);
    }
}
