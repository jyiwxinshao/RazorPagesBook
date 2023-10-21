using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook105.Models;

namespace RazorPagesBook105.Data
{
    public class RazorPagesBook105Context : DbContext
    {
        public RazorPagesBook105Context (DbContextOptions<RazorPagesBook105Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesBook105.Models.Book> Book { get; set; } = default!;

        public DbSet<RazorPagesBook105.Models.Borrow> Borrow { get; set; } = default!;

        public DbSet<RazorPagesBook105.Models.Student> Student { get; set; } = default!;
    }
}
