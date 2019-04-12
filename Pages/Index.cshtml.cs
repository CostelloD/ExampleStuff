using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestExamples.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }



        public void OnGet()
        {
            Response.Cookies.Append("testing", "hello");

            if (Request.Cookies["testing"] != null)
            {
                Message = "Welcome BAck";
            }

            //var cookieOptions = new CookieOptions
            //{
            //    Expires = DateTime.Now.AddMilliseconds(30)
            //};
            //Response.Cookies.Append("testing", "hello", cookieOptions);

        }





    }
}
