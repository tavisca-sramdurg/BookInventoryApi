using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApiSandbox.Validation
{
    public class Errors
    {
        public const string NotFound = "ERROR 404: Book that you're looking for does not exist";
        public const string BlankBookName = "ERROR: Book name cannot be blank | Eg. The Subtle Art of Not Giving a f*ck";
        public const string Valid = "Valid book";
        public const string DeletionSuccessful = "SUCCESS: Book Deleted Successfully";
        public const string BlankAuthorName = "ERROR: Author name cannot be blank | Eg. John Doe";
        public const string BlankGenreName = "ERROR: Genre cannot be blank | Eg. Non Fiction";
        public const string InvalidAuthorName = "ERROR: Author name cannot contain digits or special characters | Eg. John Doe";
        public const string InvalidGenre = "ERROR: Genre cannot contain digits or special characters | Eg. Non Fiction";
        public const string BookAlreadyExists = "ERROR: Book with the same Name already exists. Please try again with a more specific name\n" +
            "For Eg. Harry Potter: Wrong | Harry Potter and the half blood prince: Right";
    }
}
