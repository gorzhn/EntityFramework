using EFHomework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFHomework.DataAccessLayer
{
    public class LibraryContext : DbContext
    {
  
        public LibraryContext(DbContextOptions<LibraryContext> options)  : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
