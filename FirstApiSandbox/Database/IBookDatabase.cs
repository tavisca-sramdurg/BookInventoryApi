using System.Collections.Generic;
using FirstApiSandbox.Model;

namespace FirstApiSandbox.Database
{
    public interface IBookDatabase
    {
        List<Book> GetBooksFromDatabase();
        Book GetBooksFromDatabaseByName(string name);
        void AddBookInDatabase(Book newBook);
        void UpdateBookInDatabase(string name, Book newBook);
        void DeleteBookFromDatabase(string name);
        List<Book> GetBooksByGenreFromDatabase(string genreName);
    }
}