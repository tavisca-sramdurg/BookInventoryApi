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
        IService bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.GetBooksfromService();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            return bookService.GetBooksFromDatabaseAtIndex(id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            bookService.AddBookUsingService(newBook);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book newBook)
        {
            bookService.UpdateBookUsingService(id, newBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.DeleteBookUsingService(id);
        }
    }
}
