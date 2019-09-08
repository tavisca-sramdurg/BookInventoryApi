using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;

namespace FirstApiSandbox.Service
{
    public interface IService
    {
        Response GetBooksfromService();
        Response GetBookFromServiceByName(string name);
        Response AddBookUsingService(Book newBook);
        Response UpdateBookUsingService(string name, Book newBook);
        Response DeleteBookUsingService(string name);
    }
}
