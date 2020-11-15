using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookManagement.Models
{
    public class BookManagementDBContext : DbContext
    {
        
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<Book> Book { get; set; }
       
    }
}