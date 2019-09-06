using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Book GetBooksFromDatabaseAtIndex(string name)
        {
            Debug.WriteLine(name);

            var bookToBeReturned = bookList.Where(iteratorBook => iteratorBook.Name.Equals(name)).FirstOrDefault();
            Debug.WriteLine(bookToBeReturned);
            return bookToBeReturned;
        }

        public void AddBookInDatabase(Book newBook)
        {
            bookList.Add(newBook);
        }

        public bool UpdateBookInDatabase(string name, Book newBook)
        {
            try
            {
                bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Author = newBook.Author;
                bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Genre = newBook.Genre;
                bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Name = newBook.Name;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteBookFromDatabase(string name)
        {
            try
            {
                bookList.RemoveAt(bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault()));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
