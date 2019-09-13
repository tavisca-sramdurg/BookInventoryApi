using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApiSandbox.Model;
using FirstApiSandbox.Database;
using FluentValidation;

namespace FirstApiSandbox.Validation
{
    public class BookValidation : AbstractValidator<Book> 
    {
        #region Experimenting Fluent Validation *Commented code*
        public BookValidation()
        {
            RuleFor(newBook => newBook.Name)
                .NotEmpty()
                .WithMessage("ERROR: Book name cannot be blank | Eg.The Subtle Art of Not Giving a f*ck")
                .NotEqual(" ")
                .WithMessage("ERROR: Book name cannot be blank | Eg.The Subtle Art of Not Giving a f*ck");
            RuleFor(newBook => newBook.Genre)
                .NotEmpty()
                .WithMessage("ERROR: Genre cannot be blank | Eg. Non Fiction")
                .NotEqual(" ")
                .WithMessage("ERROR: Genre cannot be blank | Eg. Non Fiction");
            RuleFor(newBook => newBook.Author)
                .NotEmpty()
                .WithMessage("ERROR: Author name cannot be blank | Eg. John Doe")
                .NotEqual(" ")
                .WithMessage("ERROR: Author name cannot be blank | Eg. John Doe"); 

            RuleFor(newBook => newBook.Genre)
                .Matches(@"^[a-zA-Z ]+$")
                .WithMessage("ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction");

            RuleFor(newBook => newBook.Author)
                .Matches(@"^[a-zA-Z ]+$")
                .WithMessage("ERROR: Author name cannot contain digits or special characters | Eg.John Doe");
            
            RuleFor(newBook => newBook.Name)
                .Must(MustNotContainBook)
                .WithMessage("Book with the same Name already exists. Please try again with a more specific name\n" +
            "For Eg. Harry Potter: Wrong | Harry Potter and the half blood prince: Right");
        }
        #endregion

        //public static string IsBookValid(Book newBook)
        //{
        //    if (newBook.Name.Equals(""))
        //        return Errors.BlankBookName;
        //    if (newBook.Author.Equals(""))
        //        return Errors.BlankAuthorName;
        //    if (newBook.Genre.Equals(""))
        //        return Errors.BlankGenreName;
        //    if (!newBook.Author.All(c => char.IsLetter(c) || c==' '))
        //        return Errors.InvalidAuthorName;
        //    if (!newBook.Genre.All(c => char.IsLetter(c) || c == ' '))
        //        return Errors.InvalidGenre;
        //    if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(newBook.Name)).FirstOrDefault() != null)
        //        return Errors.BookAlreadyExists;

        //    return Errors.Valid;
        //}

        public bool MustNotContainBook(string newBookName)
        {
            if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(newBookName)).FirstOrDefault() != null)
                return false;
            else
                return true;
        }

        public static bool IfQueriedBookNameExists(string name)
        {
            if (BookData.bookList.Where(iteratorBook => iteratorBook.Name.Equals(name)).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
    }
}
