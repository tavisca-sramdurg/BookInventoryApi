using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;

namespace FirstApiSandbox.Database
{
    public class BookData : IBookDatabase
    {
        

        public static List<Book> bookList = new List<Book> {
            new Book{ Name="EmptyList", Genre="NA", Author="NA" }
        };

        public List<Book> GetBooksFromDatabase()
        {
            return bookList;
        }

        public Book GetBooksFromDatabaseByName(string name)
        {
            //Debug.WriteLine(name);

            var bookToBeReturned = bookList.Where(iteratorBook => iteratorBook.Name.Equals(name)).FirstOrDefault();
            //Debug.WriteLine(bookToBeReturned);
            return bookToBeReturned;
        }

        public void AddBookInDatabase(Book newBook)
        {
            bookList.Add(newBook);
        }

        public void UpdateBookInDatabase(string name, Book newBook)
        {
            bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Author = newBook.Author;
            bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Genre = newBook.Genre;
            bookList[bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault())].Name = newBook.Name;
        }

        public void DeleteBookFromDatabase(string name)
        {
            bookList.RemoveAt(bookList.IndexOf(bookList.Where(iteratorBook => iteratorBook.Name == name).FirstOrDefault()));
        }

        public List<Book> GetBooksByGenreFromDatabase(string genreName)
        {
            List<Book> bookListWithGenre = new List<Book>();
            foreach (Book book in bookList)
            {
                if (book.Genre.Equals(genreName))
                    bookListWithGenre.Add(book);
            }
            return bookListWithGenre;
        }
    }
}
