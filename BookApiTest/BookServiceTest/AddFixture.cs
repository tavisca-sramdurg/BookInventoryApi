using FirstApiSandbox;
using FirstApiSandbox.Database;
using FirstApiSandbox.Model;
using FirstApiSandbox.Service;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookApiTest.BookServiceTest
{
    public class AddFixture
    {
        [Fact]
        public void AddBookFromService_should_add_book_to_bookList()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name="RichDadPoorDad", Genre="Lifestyle", Author="Robert" }
            };

            //Act
            bookService.AddBookUsingService(new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" });
            Response mockResponse = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), mockResponse.ResponseBookList.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_newBook_name_is_blank()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Book name cannot be blank | Eg.The Subtle Art of Not Giving a f*ck";
            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "", Genre = "Lifestyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_Author_name_is_blank()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Author name cannot be blank | Eg. John Doe";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_Author_name_contains_digits_or_special_chars()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Author name cannot contain digits or special characters | Eg.John Doe";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "Rob38945ert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_genre_contains_digits_or_special_chars()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lif56estyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_genre_is_blank()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Genre cannot be blank | Eg. Non Fiction";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }
    }
}
