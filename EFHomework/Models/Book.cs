using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFHomework.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }

    }
}
