using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using System;
using System.Linq;
using MvcBookStore.Models;
using BookStore.Models;

public static class SeedDataAutori
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookStoreContext>>()))
        {
            // Look for any movies.
            if (context.Autori.Any())
            {
                return;   // DB has been seeded
            }
            context.Autori.AddRange(
                new Autori
                {
                    Nume="Mihai Eminescu",
                    BirthDay=DateTime.Parse("1850-01-15"),
                    Country="Romania",
                    WrittenBooks="55",
                    Rating="5/5"
                }

            );
            context.SaveChanges();
        }
    }
}