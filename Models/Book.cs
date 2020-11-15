using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManagement.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]

        public string PublicationYear { get; set; }
        public int Stock { get; set; }
        [Required]

        public int AuthorID { get; set; }
        public Author Author { get; set; }
        [Required]

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        [Required]

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Required]

        public int ShelfID { get; set; }
        public Shelf Shelf { get; set; }
    }
}