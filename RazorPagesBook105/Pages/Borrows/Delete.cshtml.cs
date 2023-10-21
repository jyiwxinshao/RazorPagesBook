using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook105.Data;
using RazorPagesBook105.Models;

namespace RazorPagesBook105.Pages.Borrows
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesBook105.Data.RazorPagesBook105Context _context;

        public DeleteModel(RazorPagesBook105.Data.RazorPagesBook105Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Borrow Borrow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrow == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrow.FirstOrDefaultAsync(m => m.Id == id);

            if (borrow == null)
            {
                return NotFound();
            }
            else 
            {
                Borrow = borrow;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Borrow == null)
            {
                return NotFound();
            }
            var borrow = await _context.Borrow.FindAsync(id);

            if (borrow != null)
            {
                Borrow = borrow;
                _context.Borrow.Remove(Borrow);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
