using System;
using Xunit;
using FirstApiSandbox.Service;
using FirstApiSandbox.Model;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using FirstApiSandbox.Database;
using FirstApiSandbox.Service;
using FirstApiSandbox;

namespace BookApiTest.BookServiceTest
{
    public class GetFixture
    {
        #region  GET_TESTS
        [Fact]
        public void GetBooksFromService_should_return_empty_template_book()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" }
            };

            //Act
            //List<Book> actualBookList = bookService.GetBooksfromService();
            Response mockResponse = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), mockResponse.ResponseBookList.ToString());
        }

        [Fact]
        public void GetBooksFromServiceByName_should_return_book_by_given_name()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name="Hunger", Genre="Fiction", Author="Suzanne Collins" }
            };
            Book expectedBook = expectedBookList[0];

            //Act
            Response mockResponse = bookService.GetBookFromServiceByName(expectedBook.Name);

            //Assert
            Assert.Equal(expectedBook?.ToString(), mockResponse.Data?.ToString());
        }
        #endregion
    }
}
