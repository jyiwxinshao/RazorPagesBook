using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RazorPagesBook105.Data;
using RazorPagesBook105.Models;

namespace RazorPagesBook105.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook105.Data.RazorPagesBook105Context _context;

        public IndexModel(RazorPagesBook105.Data.RazorPagesBook105Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genders { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? StudentGender { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of ISBNs
            IQueryable<string> genderQuery = from b in _context.Student orderby b.Gender select b.Gender;

            var students = from b in _context.Student select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.readerNumber.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(StudentGender))
            {
                students = students.Where(x => x.Gender == StudentGender);
            }
            Genders = new SelectList(await genderQuery.Distinct().ToListAsync());
            Student = await students.ToListAsync();
        }
    }
}
