using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestExamples.Models;

namespace TestExamples.Pages
{
    public class ConfirmPersonModel : PageModel
    {
        private readonly PersonContext _db;

        public ConfirmPersonModel(PersonContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Person Person { get; set; }

        [TempData]
        public string Message { get; set; }

        /* Onget takes Name as parameter so we can call correct object/record from the database*/
        public async Task<IActionResult> OnGetAsync(string ChildFirstNAme)
        {
            Person = await _db.People.FindAsync(ChildFirstNAme);

            if (Person == null)
            {
                return NotFound();
            }
            //methods to list the days and calculate the costs

            return Page();
        }

        public IList<Person> People { get; private set; }
    }
}