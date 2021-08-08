using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer //use to initilalze database
    {
        public static void Seed(IApplicationBuilder applicationBuilder)//enableadd data into database if empty
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();//create reference to DB context
                if (!context.Books.Any())//check books are availabe in database
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "1st Book Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book title",
                        Description = "2nd Book Description",
                        IsRead = true,
                        Genre = "Biography",
                        Author = "1st Book Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
