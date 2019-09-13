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
    public class UpdateFixture
    {
        [Fact]
        public void UpdateBookUsingService_should_update_book_from_bookList()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            List<Book> expectedBookList = new List<Book> {
                        new Book{ Name="EmptyList", Genre="NA", Author="NA" }
                    };

            //Act
            bookService.UpdateBookUsingService("EmptyList", new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" });
            Response mockResponse = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), mockResponse.ResponseBookList.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_newBook_name_is_invalid()
        {
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR 404: Book that you're looking for does not exist";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "", Genre = "Lifestyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_Author_name_contains_digits_or_special_chars()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Author name cannot contain digits or special characters | Eg.John Doe";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("EmptyList", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "Robert45" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_Author_name_is_blank()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Author name cannot be blank | Eg. John Doe";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("EmptyList", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = ""});

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_genre_contains_digits_or_special_chars()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("EmptyList", new Book { Name = "SomeBook", Genre = "Lifestyle2039857", Author = "SomeAuthor" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_genre_is_blank()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR: Genre cannot be blank | Eg. Non Fiction";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("EmptyList", new Book { Name = "SomeBook", Genre = " ", Author = "SomeAuthor" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_searched_book_does_not_exists()
        {
            //Arrange
            IBookDatabase bookDatabase = new BookData();
            IService bookService = new BookService(bookDatabase);
            string expectedErrorMessage = "ERROR 404: Book that you're looking for does not exist";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("SomeInvalidBook", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "SomeAuthor" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }
    }
}
