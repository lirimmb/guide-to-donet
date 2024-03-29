﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mybooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st book title",
                        Description = "1st Book desc",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "TestURL",
                        DateAdded = DateTime.Now
                    },
                    new Book(){
                        Title = "2nd book title",
                        Description = "2nd Book desc",
                        IsRead = false,
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "TestURL",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
            
    }
}
