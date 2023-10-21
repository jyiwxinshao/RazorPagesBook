using Microsoft.EntityFrameworkCore;
using RazorPagesBook105.Data;
using RazorPagesBook105.Models;

namespace RazorPagesBook.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesBook105Context(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesBook105Context>>()))
        {
            if (context == null || context.Book == null || context.Student == null || context.Borrow == null)
            {
                throw new ArgumentException("Null RazorPagesBookContext");
            }

            // Look for any books.
            if (context.Book.Any() && context.Student.Any() && context.Borrow.Any())
            {
                return;     // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "Le Petit Prince",
                    Writer = "Antoine de Saint-Exupéry",
                    Press = "海燕出版社",
                    ISBN = "97875016",
                    Price = 19.9M,
                    State = true,
                    Rating = "R"

                },

                new Book
                {
                    Title = "Vingt mille lieues sous les mers",
                    Writer = "Jules Verne",
                    Press = "译林出版社",
                    ISBN = "97875581",
                    Price = 14.3M,
                    State = false,
                    Rating = "R"
                }
                );

            context.Student.AddRange(
                new Student
                {
                    readerNumber = "22133105",
                    Name = "张华",
                    Gender = "男",
                    Birthday = DateTime.Parse("1995-06-10"),
                    Address = "天津市",
                    Phone = "12345678900",
                },

                new Student
                {
                    readerNumber = "22133135",
                    Name = "王科序",
                    Gender = "女",
                    Birthday = DateTime.Parse("1995-04-15"),
                    Address = "浙江省宁波市",
                    Phone = "12345678908",
                }
                );

            context.Borrow.AddRange(
                new Borrow
                {
                    serialNumber = "2020011839",
                    ISBN = "97875016",
                    readerNumber = "22133105",
                    loanDate = DateTime.Parse("2017-03-15"),
                    returnDate = DateTime.Parse("2017-06-16"),
                },

                new Borrow
                {
                    serialNumber = "2020011840",
                    ISBN = "97875581",
                    readerNumber = "22133135",
                    loanDate = DateTime.Parse("2020-01-18"),
                    returnDate = DateTime.Parse("2020-01-21"),
                }
                );
            context.SaveChanges();
        }
    }
}
