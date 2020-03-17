using EFHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFHomework.DataAccessLayer
{
#pragma warning disable IDE1006 // Naming Styles
   public interface LibraryRepository 
#pragma warning restore IDE1006 // Naming Styles
    {
       Book GetBook(int? id);
        IEnumerable<Book> GetAllBooks();
        Book AddBook(Book b);
        Book UpdateBook(Book b);
        void DeleteBook(int? id);

        List<Author> GetAllAuthors();
        Author AddAuthor(Author a);
        Author GetAuthor(int? id);
        Author UpdateAuthor(Author a);
        void DeleteAuthor(int? id);

        //search
        IEnumerable<Book> LookupBook(string value);

        
        
    }
}
