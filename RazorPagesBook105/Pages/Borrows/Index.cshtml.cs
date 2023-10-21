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

namespace RazorPagesBook105.Pages.Borrows
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook105.Data.RazorPagesBook105Context _context;

        public IndexModel(RazorPagesBook105.Data.RazorPagesBook105Context context)
        {
            _context = context;
        }

        public IList<Borrow> Borrow { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? ISBNs { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BorrowISBN { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of ISBNs
            IQueryable<string> ISBNQuery = from b in _context.Borrow orderby b.ISBN select b.ISBN;

            var borrows = from b in _context.Borrow select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                borrows = borrows.Where(s => s.serialNumber.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BorrowISBN))
            {
                borrows = borrows.Where(x => x.ISBN == BorrowISBN);
            }
            ISBNs = new SelectList(await ISBNQuery.Distinct().ToListAsync());
            Borrow = await borrows.ToListAsync();
        }
    }
}
