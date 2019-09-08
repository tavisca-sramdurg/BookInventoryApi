using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FirstApiSandbox.Service;
using FirstApiSandbox.Validation;
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
        public ActionResult<List<Book>> Get()
        {
            Response response = bookService.GetBooksfromService();
            return Ok(response.ResponseBookList);
        }

        // GET: api/Book/5
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<Book> Get(string name)
        {
            Response response = bookService.GetBookFromServiceByName(name);
            
            if (response.Data != null)
            {
                return Ok(response.Data);
            }

            return NotFound(response.ErrorMessage);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book newBook)
        {
            Response response = bookService.AddBookUsingService(newBook);

            if (response.Data != null)
            {
                return Ok(response.Data);
            }

            return NotFound(response.ErrorMessage);
            
        }

        // PUT: api/Book/5
        [HttpPut("{name}")]
        public ActionResult<Book> Put(string name, [FromBody] Book newBook)
        {
            Response response = bookService.UpdateBookUsingService(name, newBook);
            if (response.Data != null)
            {
                return Ok(response.Data);
            }

            return NotFound(response.ErrorMessage);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            Response response = bookService.DeleteBookUsingService(name);

            if (response.Data != null)
            {
                return Ok(response.Data);
            }
            return NotFound(response.ErrorMessage);
        }
    }
}
