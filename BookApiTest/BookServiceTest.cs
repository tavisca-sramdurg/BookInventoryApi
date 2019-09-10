using System;
using Xunit;
using FirstApiSandbox.Service;
using FirstApiSandbox.Model;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using FirstApiSandbox;

namespace BookApiTest
{
    public class BookServiceTest
    {
        #region  GET_TESTS
        [Fact]
        public void GetBooksFromService_should_return_empty_template_book()
        {
            //Arrange
            IService bookService = new BookService();
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
            //Arrange
            IService bookService = new BookService();
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

        #region ADD_TESTS
        [Fact]
        public void AddBookFromService_should_add_book_to_bookList()
        {
            //Arrange
            IService bookService = new BookService();
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
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Book name cannot be blank | Eg. The Subtle Art of Not Giving a f*ck";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "", Genre = "Lifestyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage.ToString());
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_Author_name_contains_digits_or_special_chars()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Author name cannot contain digits or special characters | Eg. John Doe"; ;

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "Rob38945ert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_Author_name_is_blank()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Author name cannot be blank | Eg. John Doe";

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_genre_contains_digits_or_special_chars()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction"; ;

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "Lif56estyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void AddBookFromService_should_return_corresponding_error_message_if_genre_is_blank()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Genre cannot be blank | Eg. Non Fiction"; 

            //Act
            Response mockResponse = bookService.AddBookUsingService(new Book { Name = "SomeBook", Genre = "", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }


        #endregion

        #region UPDATE_TESTS

        [Fact]
        public void UpdateBookUsingService_should_update_book_from_bookList()
        {
            //Arrange
            IService bookService = new BookService();
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
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Book name cannot be blank | Eg. The Subtle Art of Not Giving a f*ck"; ;

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "", Genre = "Lifestyle", Author = "Robert" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_Author_name_contains_digits_or_special_chars()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Author name cannot contain digits or special characters | Eg. John Doe";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "Robert45" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_Author_name_is_blank()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Author name cannot be blank | Eg. John Doe";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_genre_contains_digits_or_special_chars()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction"; 

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "SomeBook", Genre = "Lifestyle2039857", Author = "SomeAuthor" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        [Fact]
        public void UpdateBookUsingService_should_return_corresponding_error_message_if_genre_is_blank()
        {
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR: Genre cannot be blank | Eg. Non Fiction";

            //Act
            Response mockResponse = bookService.UpdateBookUsingService("Subtle Art of not giving a f*ck", new Book { Name = "SomeBook", Genre = "", Author = "SomeAuthor" });

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        //[Fact]
        //public void UpdateBookUsingService_should_return_corresponding_error_message_if_searched_book_does_not_exists()
        //{
        //    //Arrange
        //    IService bookService = new BookService();
        //    string expectedErrorMessage = "ERROR 404: Book that you're looking for does not exist";

        //    //Act
        //    Response mockResponse = bookService.UpdateBookUsingService("SomeInvalidBook", new Book { Name = "SomeBook", Genre = "Lifestyle", Author = "SomeAuthor" });

        //    //Assert
        //    Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        //}

        #endregion

        #region DELETE_TESTS

        [Fact]
        public void DeleteBookUsingService_should_delete_book_from_bookList()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                
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
            //Arrange
            IService bookService = new BookService();
            string expectedErrorMessage = "ERROR 404: Book that you're looking for does not exist";
            //Act
            Response mockResponse = bookService.DeleteBookUsingService("SomeInvalidBook");

            //Assert
            Assert.Equal(expectedErrorMessage, mockResponse.ErrorMessage);
        }

        #endregion
    }
}
