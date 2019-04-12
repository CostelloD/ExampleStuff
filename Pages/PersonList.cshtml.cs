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
    public class PersonListModel : PageModel
    {

        [TempData]
        public string Message { get; set; }

        private readonly PersonContext _db;

        public PersonListModel(PersonContext db)
        {
            _db = db;
        }

        public IList<Person> People { get; private set; }

        public async Task OnGetAsync()
        {
            People = await _db.People.AsNoTracking().ToListAsync();
        }
    }
}