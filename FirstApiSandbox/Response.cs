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


        public Response(string validationErrorMessage)
        {
            this.ErrorMessage = validationErrorMessage;
        }

        public Response(Book book)
        {
            Data = book;
        }

        public Response(List<Book> bookList)
        {
            ResponseBookList = bookList;
        }
    }
}
