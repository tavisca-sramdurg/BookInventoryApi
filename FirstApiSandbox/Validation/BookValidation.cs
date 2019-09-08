using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;

namespace FirstApiSandbox.Validation
{
    public class BookValidation
    {
        public static string IsBookValid(Book newBook)
        {
            if (newBook.Name.Equals(""))
                return Errors.BlankBookName;
            if (newBook.Author.Equals(""))
                return Errors.BlankAuthorName;
            if (newBook.Genre.Equals(""))
                return Errors.BlankGenreName;
            if (!newBook.Author.All(c => char.IsLetter(c) || c==' '))
                return Errors.InvalidAuthorName;
            if (!newBook.Genre.All(c => char.IsLetter(c) || c == ' '))
                return Errors.InvalidGenre;
            if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(newBook.Name)).FirstOrDefault() != null)
                return Errors.BookAlreadyExists;

            return Errors.Valid;
        }
    }
}
