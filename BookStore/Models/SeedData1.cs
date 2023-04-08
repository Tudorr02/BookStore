using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using System;
using System.Linq;
using MvcBookStore.Models;



public static class SeedData1
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookStoreContext>>()))
        {
            // Look for any movies.
            if (context.Book1.Any())
            {
                return;   // DB has been seeded
            }
            context.Book1.AddRange(
                new Book1
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                }

            );
            context.SaveChanges();
        }
    }
}