using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using System;
using System.Linq;
using MvcBookStore.Models;
using BookStore.Models;

public static class SeedDataLocations
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BookStoreContext>>()))
        {
            // Look for any movies.
            if (context.Locations.Any())
            {
                return;   // DB has been seeded
            }
            context.Locations.AddRange(

                 new Locations
                 {
                     Country = "United States",
                     City = "New York City",
                     Adress = "123 Main St",
                     Opens = "9:00am",
                     Closes = "5:00pm"
                 },
                new Locations
                {
                    Country = "Canada",
                    City = "Toronto",
                    Adress = "456 Queen St",
                    Opens = "8:30am",
                    Closes = "4:30pm"
                },
                new Locations
                {
                    Country = "United Kingdom",
                    City = "London",
                    Adress = "789 Oxford St",
                    Opens = "10:00am",
                    Closes = "6:00pm"
                },
                new Locations
                {
                    Country = "United Kingdom",
                    City = "London",
                    Adress = "789 Oxford St",
                    Opens = "10:00am",
                    Closes = "6:00pm"
                },
                new Locations
                {
                    Country = "United Kingdom",
                    City = "London",
                    Adress = "789 Oxford St",
                    Opens = "10:00am",
                    Closes = "6:00pm"
                },
                new Locations
                {
                    Country = "United Kingdom",
                    City = "London",
                    Adress = "789 Oxford St",
                    Opens = "10:00am",
                    Closes = "6:00pm"
                }

            );
            context.SaveChanges();
        }
    }
}