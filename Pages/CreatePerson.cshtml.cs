using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestExamples.Models;

namespace TestExamples.Pages
{
    public class CreatePersonModel : PageModel
    {
        //enum for relationship
        public enum Relationship
        {
            Mother = 0,
            Father,
            Other,
        }
        //enum for monday to friday
        public enum SelectedDays
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        [TempData]
        public string Message { get; set; }


        private readonly PersonContext _db;

        public CreatePersonModel(PersonContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Person Person { get; set; } = new Person();



        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {

                _db.People.Add(Person);
                await _db.SaveChangesAsync();
                Message = $"{Person.ChildFirstNAme} has been added to the database";
                //go to confirmation page using PPS number as key for correct object
                return RedirectToPage("/ConfirmPerson", new { Person.ChildFirstNAme });
            }

            else
            {
                return Page();
            }
        }


        public void OnGet()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMilliseconds(30)
            };
            Response.Cookies.Append("testing", "hello", cookieOptions);

        }
    }
}