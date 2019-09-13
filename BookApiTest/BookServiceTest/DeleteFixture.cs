using FirstApiSandbox;
using FirstApiSandbox.Database;
using FirstApiSandbox.Model;
using FirstApiSandbox.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookApiTest.BookServiceTest
{
    public class DeleteFixture
    {
        [Fact]
        public void DeleteBookUsingService_should_delete_book_from_bookList()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            List<Book> expectedBookList = new List<Book>
            {

            };

            //Act
            bookService.DeleteBookUsingService("EmptyList");
            Response mockResponse = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), mockResponse.ResponseBookList.ToString());
        }

        [Fact]
        public void DeleteBookUsingService_should_return_NotFound_error_when_book_to_be_deleted_does_not_exist()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR 404: Book that you're looking for does not exist";
            //Act
            Response mockResponse = bookService.DeleteBookUsingService("SomeInvalidBook");

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }
    }
}
