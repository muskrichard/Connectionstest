using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connectionstest.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Connectionstest.Pages.ConnectionsPages
{

        public class createModel : PageModel
        {
            private ApplicationDbContext _db;

            public createModel(ApplicationDbContext db)
            {
                _db = db;
            }

            [TempData]
            public string afterAddMessage { get; set; }

            [BindProperty]
            public Connections Connection { get; set; }
            public void OnGet()
            {
            }

            public async Task<IActionResult> OnPost()
            {
                if (!ModelState.IsValid)
                {
                    // return to the page
                    return Page();
                }
                else
                {
                    // if it IS valid, then we'll add our Connection
                    _db.ConnectionsItems.Add(Connection);

                    await _db.SaveChangesAsync();


                    afterAddMessage = "New Connnection made!";

                    return RedirectToPage("Index");
                }
            }
        }
    }