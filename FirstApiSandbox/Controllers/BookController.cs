using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FirstApiSandbox.Service;
using System.Linq;

namespace FirstApiSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //public static List<Book> bookList = new List<Book> {
        //    new Book{ Name="AngelsAndDemons", Genre="Fiction", Author="Dan Brown" },
        //    new Book { Name = "Da VinciCode", Genre = "Fiction", Author = "Dan Brown" }
        //};

        BookService bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            //return bookList;
            return bookService.GetBooksfromService();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        //public Book Get(int id)
        //{
        //    //return bookList.ElementAt(id);

        //}

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            //bookList.Add(newBook);
            bookService.AddBookUsingService(newBook);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book newBook)
        {
            //bookList[id].Name = newBook.Name;
            //bookList[id].Genre = newBook.Genre;
            //bookList[id].Author = newBook.Author;
            bookService.UpdateBookUsingService(id, newBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //bookList.RemoveAt(id);
            bookService.DeleteBookUsingService(id);
        }
    }
}
