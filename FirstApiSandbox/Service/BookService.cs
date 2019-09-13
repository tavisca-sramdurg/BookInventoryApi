using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FirstApiSandbox.Validation;
using FluentValidation.Results;
using ServiceStack.Redis;

namespace FirstApiSandbox.Service
{
    public class BookService : IService
    {
        private IBookDatabase bookData;
        RedisManagerPool redisManager = new RedisManagerPool("localhost:6379");
        IRedisClient redisClient;

        public BookService(IBookDatabase bookDatabase)
        {
            bookData = bookDatabase;
            redisClient = redisManager.GetClient();
        }

        public Response GetBooksfromService()
        {
            var returnedBookList = bookData.GetBooksFromDatabase();
            Response response = new Response(returnedBookList);
            return response;
        }

        public Response GetBookFromServiceByName(string name)
        {
            if (BookValidation.IfQueriedBookNameExists(name))
            {
                if (redisClient.Get<Book>(name) != null)
                {
                    //Book found in Cache
                    var returnedBook = redisClient.Get<Book>(name);
                    Response response = new Response(returnedBook);
                    return response;
                }
                else
                {
                    //Book found in Database
                    var returnedBook = bookData.GetBooksFromDatabaseByName(name);
                    redisClient.Set(returnedBook.Name, returnedBook, TimeSpan.FromMinutes(1));
                    Response response = new Response(returnedBook);
                    return response;
                }
            }
            else
            {
                Response response = new Response(Errors.NotFound);
                return response;
            }


            #region  Safe Code
            //if (BookValidation.IfQueriedBookNameExists(name))
            //{
            //    var returnedBook = bookData.GetBooksFromDatabaseByName(name);
            //    Response response = new Response(returnedBook);

            //    return response;
            //}
            //else
            //{
            //    Response response = new Response(Errors.NotFound);
            //    return response;
            //}     
            #endregion
        }

        public Response AddBookUsingService(Book newBook)
        {
            Response response;

            BookValidation bookValidator = new BookValidation();
            ValidationResult result = bookValidator.Validate(newBook);

            if (result.IsValid)
            {
                bookData.AddBookInDatabase(newBook);
                var returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                response = new Response(returnedBook);
                return response;
            }
            else
            {
                IList<ValidationFailure> validationFailureMessages = result.Errors;
                response = new Response(validationFailureMessages[0].ErrorMessage);
                return response;
            }

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
                    if (redisClient.Get<Book>(name) != null)
                    {
                        redisClient.DeleteById<Book>(name);
                        redisClient.Set(newBook.Name, newBook, TimeSpan.FromMinutes(1));
                    }
                    Book returnedBook = bookData.GetBooksFromDatabaseByName(newBook.Name);
                    response = new Response(returnedBook);
                    return response;
                }
                else
                {
                    IList<ValidationFailure> validationFailureMessages = result.Errors;
                    response = new Response(validationFailureMessages[0].ErrorMessage);
                    return response;
                }
            }
            else
                return new Response(Errors.NotFound); ;
        }

        public Response DeleteBookUsingService(string name)
        {
            if (BookValidation.IfQueriedBookNameExists(name))
            {
                bookData.DeleteBookFromDatabase(name);
                if (redisClient.Get<Book>(name) != null)
                {
                    redisClient.DeleteById<Book>(name);
                }
                return new Response(Errors.DeletionSuccessful);
            }
            else
                return new Response(Errors.NotFound);

        }

        public Response GetBookByGenreUsingService(string genreName)
        {
            var returnedBookList = bookData.GetBooksByGenreFromDatabase(genreName);
            Response response = new Response(returnedBookList);
            return response;
        }

    }
}
