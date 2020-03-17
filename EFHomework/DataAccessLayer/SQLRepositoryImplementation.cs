
using EFHomework.DataAccessLayer;
using EFHomework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFHomework.DataAccessLayer
{
    public class SQLRepositoryImplementation : LibraryRepository
    {
        private readonly LibraryContext context;
        public SQLRepositoryImplementation(LibraryContext context)
        {
            this.context = context;

        }
        public Author AddAuthor(Author a)
        {
            context.Authors.Add(a);
            context.SaveChanges();
            return a;
            
        }

        public void DeleteAuthor(int? id)
        {
            var author = context.Authors.Where(x => x.Id == id).First();
            context.Authors.Remove(author);
            context.SaveChanges();
            
        }
        public List<Author> GetAllAuthors()
        {
            return context.Authors.ToList();
        }

        public Author UpdateAuthor(Author a)
        {
            var author = context.Authors.Attach(a);
            author.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return a;
        }
        public Author GetAuthor(int? id)
        {
            return context.Authors.Where(x => x.Id == id).FirstOrDefault();
        }

        public Book AddBook(Book b)
        {
            context.Books.Add(b);
            context.SaveChanges();
            return b;
        }
      

        public void DeleteBook(int? id)
        {
            var book = context.Books.Where(x => x.Id == id).First();
            context.Books.Remove(book);
            context.SaveChanges();
        }

       

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

     

        public Book GetBook(int? id)
        {
            return context.Books.Where(x => x.Id == id).FirstOrDefault();
        }


        public Book UpdateBook(Book b)
        {
            var book = context.Books.Attach(b);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return b;
        }

        //lookup book
        public IEnumerable<Book> LookupBook(string value)
        {


            int? authorId = context.Authors.Where(x => x.Name.Contains(value)).FirstOrDefault()?.Id;
            if (authorId != null) {
                return context.Books.Where(x => x.AuthorId == authorId).ToList();
            }
            int? bookId = context.Books.Where(x => x.Name.Contains(value)).FirstOrDefault()?.Id;
            if (bookId != null) {
                return context.Books.Where(x => x.Id == bookId).ToList();
            }
            return GetAllBooks();
         
        }
    }
}
