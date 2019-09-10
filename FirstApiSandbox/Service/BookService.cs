using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FirstApiSandbox.Validation;
using FluentValidation.Results;

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

            #region Experimenting Fluent Validation *Commented code*
            BookValidation bookValidator = new BookValidation();
            ValidationResult result = bookValidator.Validate(newBook);
            //ruleSet: "MustNotBeEmpty"

            if (result.IsValid)
            {
                bookData.AddBookInDatabase(newBook);
                var returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                response = new Response(returnedBook, null);
                return response;
            }
            else
            {
                IList<ValidationFailure> validationFailureMessages = result.Errors;
                response = new Response(validationFailureMessages);
                return response;
            }
            #endregion

            #region Experimenting Without Fluent Validation *Commented code*
            //string validationCode = BookValidation.IsBookValid(newBook);
            //if (validationCode.Equals(Valid))
            //{
            //    bookData.AddBookInDatabase(newBook);
            //    var returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
            //    response = new Response(returnedBook, null);
            //    return response;
            //}
            //else
            //{
            //    response = new Response(null, validationCode);
            //    return response;
            //}
            #endregion
        }

        public Response UpdateBookUsingService(string name, Book newBook)
        {
            Response response;
            if (BookValidation.IfQueriedBookNameExists(name))
            {
                BookValidation bookValidator = new BookValidation();
                ValidationResult result = bookValidator.Validate(newBook);
                //ruleSet: "MustNotBeEmpty"

                if (result.IsValid)
                {
                    bookData.UpdateBookInDatabase(name, newBook);
                    Book returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                    response = new Response(returnedBook, null);
                    return response;
                }
                else
                {
                    IList<ValidationFailure> validationFailureMessages = result.Errors;
                    response = new Response(validationFailureMessages);
                    return response;
                }
            }
            else
            {
                response = new Response(null, Errors.NotFound);
                return response;
            }

            
            #region Experimenting Without Fluent Validation *Commented code*
            //string validationCode = BookValidation.IsBookValid(newBook);
            //if (validationCode.Equals(Valid))
            //{
            //    bookData.UpdateBookInDatabase(name, newBook);
            //    Book returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
            //    response = new Response(returnedBook, null);
            //    return response;
            //}
            //else
            //{
            //    response = new Response(null, validationCode);
            //    return response;
            //}
            #endregion
        }

        public Response DeleteBookUsingService(string name)
        {
            //if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(name)).FirstOrDefault() == null)
            //    return new Response(null, Errors.NotFound);

            bookData.DeleteBookFromDatabase(name);
            return new Response(null, Errors.DeletionSuccessful);


        }

    }
}
