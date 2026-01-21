
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        // This method accepts IApplicationBuilder so we can access the Services container
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // We create a scope to get a reference to the database context
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // 1. Ensure the database is created
                context.Database.EnsureCreated();

                // 2. Check if the table is empty (prevent duplicating data)
                //if (!context.Books.Any())
                //{
                //    // 3. Add the new data
                //    context.Books.AddRange(new Book()
                //    {
                //        Title = "1st Book Title",
                //        Description = "1st Book Description",
                //        IsRead = true,
                //        DateRead = DateTime.Now.AddDays(-10),
                //        Rate = 4,
                //        Genre = "Biography",
                //        Author = "First Author",
                //        CoverUrl = "https://...",
                //        DateAdded = DateTime.Now
                //    });

                //    // 4. Commit changes to the database
                //    context.SaveChanges();
                //}
            }
        }
    }
}