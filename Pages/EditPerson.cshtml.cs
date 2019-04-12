using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestExamples.Models;

namespace TestExamples.Pages
{
    public class EditPersonModel : PageModel
    {
        private readonly PersonContext _db;

        public EditPersonModel(PersonContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Person = await _db.People.FirstOrDefaultAsync(s => s.ChildFirstNAme == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Person).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Student {Person.ChildFirstNAme} not found!");
            }

            return RedirectToPage("/PersonList");
        }
    }
}