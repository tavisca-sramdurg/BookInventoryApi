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
        public ActionResult<Book> Get(int id)
        {
            var returnedBook = bookService.GetBooksFromDatabaseAtIndex(id);
            if(returnedBook != null)
            {
                return Ok(returnedBook);
            }

            return NotFound("Book that you're looking for does not exist");
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            bookService.AddBookUsingService(newBook);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book newBook)
        {
            if (bookService.UpdateBookUsingService(id, newBook))
                return Ok(bookService.GetBooksFromDatabaseAtIndex(id));

            return NotFound();
            //bookService.UpdateBookUsingService(id, newBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (bookService.DeleteBookUsingService(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
