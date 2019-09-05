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
            try
            {
                return bookList.ElementAt(id);
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public void AddBookInDatabase(Book newBook)
        {
            bookList.Add(newBook);
        }

        public bool UpdateBookInDatabase(int id, Book newBook)
        {
            try
            {
                bookList[id].Name = newBook.Name;
                bookList[id].Genre = newBook.Genre;
                bookList[id].Author = newBook.Author;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteBookFromDatabase(int id)
        {
            try
            {
                bookList.RemoveAt(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
