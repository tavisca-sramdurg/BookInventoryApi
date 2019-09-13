﻿using System.Collections.Generic;
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
        private IService _bookService;

        public BookController(IService bookService)
        {
            _bookService = bookService;
        }
       
        // GET: api/Book
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            //log.Info("Get Logs!");
            Response response = _bookService.GetBooksfromService();
            return Ok(response.ResponseBookList);
        }

        // GET: api/Book/5
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<Book> Get(string name)
        {
            Response response;
            response = _bookService.GetBookFromServiceByName(name);
            if (response.Data != null)
            {
                return StatusCode(200, response.Data);
            }
            return StatusCode(404, response.ErrorMessage);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book newBook)
        {
            //log.Info("Post Logs!");
            Response response = _bookService.AddBookUsingService(newBook);

            if (response.Data != null)
            {
                return StatusCode(200, response.Data);
            }

            return StatusCode(400, response.ErrorMessage);
            
        }

        // PUT: api/Book/5
        [HttpPut("{name}")]
        public ActionResult<Book> Put(string name, [FromBody] Book newBook)
        {
            Response response;
            response = _bookService.UpdateBookUsingService(name, newBook);
            if (response.Data != null)
            {
                return StatusCode(200, response.Data);
            }
            return StatusCode(400, response.ErrorMessage); 
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            Response response;

            if (BookValidation.IfQueriedBookNameExists(name))
            {
                response = _bookService.DeleteBookUsingService(name);
                return StatusCode(200, Errors.DeletionSuccessful);
            }
            else
            {
                response = new Response(Errors.NotFound);
                return StatusCode(404, response.ErrorMessage);
            }
        }

        // GET: api/Book/Fiction
        [Route("genre/{genreName}")]
        [HttpGet]
        public ActionResult GetUsingGenre(string genreName)
        {
            Response response = _bookService.GetBookByGenreUsingService(genreName);
            return Ok(response.ResponseBookList);
        }
    }
}
