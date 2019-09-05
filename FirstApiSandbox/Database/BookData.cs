using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;

namespace FirstApiSandbox.Database
{
    public class BookData
    {
        public static List<Book> bookList = new List<Book> {
            new Book{ Name="EmptyList", Genre="NA", Author="NA" }
        };

        public List<Book> GetBooksFromDatabase()
        {
            return bookList;
        }

        public Book GetBooksFromDatabaseAtIndex(int id)
        {
            return bookList.ElementAt(id);
        }

        public void AddBookInDatabase(Book newBook)
        {
            bookList.Add(newBook);
        }

        public void UpdateBookInDatabase(int id, Book newBook)
        {
            bookList[id].Name = newBook.Name;
            bookList[id].Genre = newBook.Genre;
            bookList[id].Author = newBook.Author;
        }

        public void DeleteBookFromDatabase(int id)
        {
            bookList.RemoveAt(id);
        }
    }
}
