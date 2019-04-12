using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestExamples.Models;

namespace TestExamples.Pages
{
    public class DeletePersonModel : PageModel
    {

        private readonly PersonContext _db;

        public DeletePersonModel(PersonContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Person = await _db.People.FindAsync(id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var student = await _db.People.FindAsync(Person.ChildFirstNAme);

            if (student != null)
            {
                _db.People.Remove(student);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("PersonList");
        }
    }
}