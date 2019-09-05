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
            BookData.bookList.Add(newBook);
        }

        public void UpdateBookUsingService(int id, Book newBook)
        {
            BookData.bookList[id].Name = newBook.Name;
            BookData.bookList[id].Genre = newBook.Genre;
            BookData.bookList[id].Author = newBook.Author;
        }

        public void DeleteBookUsingService(int id)
        {
            BookData.bookList.RemoveAt(id);
        }

    }
}
