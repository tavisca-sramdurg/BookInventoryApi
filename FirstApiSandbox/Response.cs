using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FluentValidation.Results;

namespace FirstApiSandbox
{
    public class Response
    {
        public Book Data { get; set; } = null;
        public string ErrorMessage { get; set; } = null;
        public List<Book> ResponseBookList { get; set; } = null;

        public IList<ValidationFailure> validationFailures { get; set; } = null;

        public Response(Book book, string errorMessage)
        {
            Data = book;
            ErrorMessage = errorMessage;
        }

        public Response(IList<ValidationFailure> validationFailures)
        {
            this.validationFailures = validationFailures;
        }

        public Response(List<Book> bookList)
        {
            ResponseBookList = bookList;
        }
    }
}
