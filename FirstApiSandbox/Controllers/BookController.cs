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
            //log.Info("Get Logs!");
            Response response = bookService.GetBooksfromService();
            return Ok(response.ResponseBookList);
        }

        // GET: api/Book/5
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<Book> Get(string name)
        {
            //log.Info("GetByName Logs!");
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
            //log.Info("Post Logs!");
            Response response = bookService.AddBookUsingService(newBook);

            if (response.Data != null)
            {
                return StatusCode(200, response.Data);
            }

            return StatusCode(400, response.validationFailures);
            
        }

        // PUT: api/Book/5
        [HttpPut("{name}")]
        public ActionResult<Book> Put(string name, [FromBody] Book newBook)
        {
            Response response;
            if(BookValidation.IfQueriedBookNameExists(name))
            {
                response = bookService.UpdateBookUsingService(name, newBook);
                if (response.Data != null)
                {
                    return StatusCode(200, response.Data);
                }
                return StatusCode(400, response.validationFailures);
            }
            else
            {
                response = new Response(null, Errors.NotFound);
                return StatusCode(404, response.ErrorMessage);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            Response response;

            if (BookValidation.IfQueriedBookNameExists(name))
            {
                response = bookService.DeleteBookUsingService(name);
                return StatusCode(200, Errors.DeletionSuccessful);
            }
            else
            {
                response = new Response(null, Errors.NotFound);
                return StatusCode(404, response.ErrorMessage);
            }
        }
    }
}
