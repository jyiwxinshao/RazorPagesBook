using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook105.Data;
using RazorPagesBook105.Models;

namespace RazorPagesBook105.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook105.Data.RazorPagesBook105Context _context;

        public IndexModel(RazorPagesBook105.Data.RazorPagesBook105Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string? SearchString { get; set; }

        public SelectList? Writers { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? BookWriter { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of writers
            IQueryable<string> writerQuery = from b in _context.Book orderby b.Writer select b.Writer;

            var books = from b in _context.Book select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookWriter))
            {
                books = books.Where(x => x.Writer == BookWriter);
            }
            
            Writers = new SelectList(await writerQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
