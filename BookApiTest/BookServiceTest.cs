using System;
using Xunit;
using FirstApiSandbox.Service;
using FirstApiSandbox.Model;
using System.Collections.Generic;


namespace BookApiTest
{
    public class BookServiceTest
    {
        [Fact]
        public void Get_books_from_service_should_return_empty_template_book()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" }
            };

            //Act
            List<Book> actualBookList = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), actualBookList.ToString());
        }

        [Fact]
        public void Add_book_from_service_should_add_book_to_bookList()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name="RichDadPoorDad", Genre="Lifestyle", Author="Robert" }
            };

            //Act
            bookService.AddBookUsingService(new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" });
            List<Book> actualBookList = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), actualBookList.ToString());
        }

        [Fact]
        public void Delete_book_from_service_should_delete_book_from_bookList()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
            };

            //Act
            bookService.AddBookUsingService(new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" });
            bookService.DeleteBookUsingService("RichDadPoorDad");
            List <Book> actualBookList = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), actualBookList.ToString());
        }

        [Fact]
        public void Update_book_from_service_should_update_book_from_bookList()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name = "HungerGames", Genre = "Fiction", Author = "Suzanne Collins" }
            };

            //Act
            bookService.UpdateBookUsingService("HungerGames", new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" });
            List<Book> actualBookList = bookService.GetBooksfromService();

            //Assert
            Assert.Equal(expectedBookList.ToString(), actualBookList.ToString());
        }

        [Fact]
        public void Update_book_from_service_should_return_false_if_name_is_blank()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name = "HungerGames", Genre = "Fiction", Author = "Suzanne Collins" }
            };

            //Assert
            Assert.False(bookService.UpdateBookUsingService("", new Book { Name = "RichDadPoorDad", Genre = "Lifestyle", Author = "Robert" }));
        }

        [Fact]
        public void Delete_book_from_service_should_return_false_if_Id_is_negative()
        {
            //Arrange
            IService bookService = new BookService();
            List<Book> expectedBookList = new List<Book> {
                new Book{ Name="EmptyList", Genre="NA", Author="NA" },
                new Book{ Name = "HungerGames", Genre = "Fiction", Author = "Suzanne Collins" }
            };

            //Assert
            Assert.False(bookService.DeleteBookUsingService("HungerGames"));
        }
    }
}
