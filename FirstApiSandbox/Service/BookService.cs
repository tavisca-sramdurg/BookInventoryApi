using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FirstApiSandbox.Validation;

namespace FirstApiSandbox.Service
{
    public class BookService : IService
    {
        public const string Valid = "Valid book";

        BookData bookData = new BookData();

        public Response GetBooksfromService()
        {
            var returnedBookList = bookData.GetBooksFromDatabase();
            Response response = new Response(returnedBookList);
            return response;
        }

        public Response GetBookFromServiceByName(string name)
        {
            var returnedBook = bookData.GetBooksFromDatabaseByName(name);
            Response response = new Response(returnedBook, Errors.NotFound);

            return response;
        }

        public Response AddBookUsingService(Book newBook)
        {
            Response response;
            string validationCode = BookValidation.IsBookValid(newBook);
            if (validationCode.Equals(Valid))
            {
                bookData.AddBookInDatabase(newBook);
                var returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                response = new Response(returnedBook, null);
                return response;
            }
            else
            {
                response = new Response(null, validationCode);
                return response;
            }
        }

        public Response UpdateBookUsingService(string name, Book newBook)
        {
            Response response;
            string validationCode = BookValidation.IsBookValid(newBook);
            if (validationCode.Equals(Valid))
            {
                bookData.UpdateBookInDatabase(name, newBook);
                Book returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                response = new Response(returnedBook, null);
                return response;
            }
            else
            {
                response = new Response(null, validationCode);
                return response;
            }
        }

        public Response DeleteBookUsingService(string name)
        {
            if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(name)).FirstOrDefault() == null)
                return new Response(null, Errors.NotFound);

            bookData.DeleteBookFromDatabase(name);
            return new Response(null, Errors.DeletionSuccessful);
        }

    }
}
