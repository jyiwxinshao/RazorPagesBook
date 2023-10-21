using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesBook105.Data;
using RazorPagesBook105.Models;

namespace RazorPagesBook105.Pages.Borrows
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesBook105.Data.RazorPagesBook105Context _context;

        public CreateModel(RazorPagesBook105.Data.RazorPagesBook105Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Borrow Borrow { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Borrow == null || Borrow == null)
            {
                return Page();
            }

            _context.Borrow.Add(Borrow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
