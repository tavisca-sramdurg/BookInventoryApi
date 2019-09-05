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
        void AddBookUsingService(Book newBook);
        void UpdateBookUsingService(int id, Book newBook);
        void DeleteBookUsingService(int id);
    }
}
