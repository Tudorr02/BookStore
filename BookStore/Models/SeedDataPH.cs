using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class SeedDataPH
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreContext>>()))
            {
                // Look for any movies.
                if (context.PH.Any())
                {
                    return;   // DB has been seeded
                }
                context.PH.AddRange(

                    new PH
                    {
                        Country = "USA",
                        Name = "Public Library of New York",
                        numberOfBooks = 1500
                    },
                new PH
                {
                    Country = "Canada",
                    Name = "Toronto Public Library",
                    numberOfBooks = 1000
                },
                new PH
                {
                    Country = "Canada",
                    Name = "Vancouver Public Library",
                    numberOfBooks = 2000
                },
                new PH
                {
                    Country = "France",
                    Name = "Bibliothèque nationale de France",
                    numberOfBooks = 10000
                },
                new PH
                {
                    Country = "Australia",
                    Name = "State Library of New South Wales",
                    numberOfBooks = 3000
                },

                new PH
                {
                    Country = "United Kingdom",
                    Name = "British Library",
                    numberOfBooks = 800
                },
                new PH
                {
                    Country = "Australia",
                    Name = "State Library of New South Wales",
                    numberOfBooks = 600
                },
                new PH
                {
                    Country = "France",
                    Name = "Bibliothèque nationale de France",
                    numberOfBooks = 400
                }
                  
                );
                context.SaveChanges();
            }
        }

    }
}
