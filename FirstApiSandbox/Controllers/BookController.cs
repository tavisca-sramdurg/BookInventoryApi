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
        //[HttpGet("{id}", Name = "Get")]
        //public ActionResult<Book> Get(int id)
        //{
        //    var returnedBook = bookService.GetBooksFromDatabaseAtIndex(id);
        //    if(returnedBook != null)
        //    {
        //        return Ok(returnedBook);
        //    }

        //    return NotFound("Book that you're looking for does not exist");
        //}

        // GET: api/Book/5
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<Book> Get(string name)
        {
            var returnedBook = bookService.GetBookFromServiceByName(name);
            if (returnedBook != null)
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
        [HttpPut("{name}")]
        public ActionResult Put(string name, [FromBody] Book newBook)
        {
            if (bookService.UpdateBookUsingService(name, newBook))
                return Ok(bookService.GetBookFromServiceByName(name));

            return NotFound();
            //bookService.UpdateBookUsingService(id, newBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            if (bookService.DeleteBookUsingService(name))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
