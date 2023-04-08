using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBookStore.Models;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBookStore.Models.Book> Book { get; set; } = default!;

        public DbSet<MvcBookStore.Models.Book1> Book1 { get; set; } = default!;

        public DbSet<BookStore.Models.Autori> Autori { get; set; } = default!;

        public DbSet<BookStore.Models.Locations> Locations { get; set; } = default!;

        public DbSet<BookStore.Models.PH> PH { get; set; } = default!;

       
    }
}
