using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connectionstest.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Connectionstest.Pages.ConnectionsPages
{
    
    public class editModel : PageModel
    {
        private ApplicationDbContext _db;

        public editModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Connections Connection { get; set; }

        [TempData]
        public string afterAddMessage { get; set; }

        public void OnGet(int id)
        {
            Connection = _db.ConnectionsItems.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var connectionInDb = _db.ConnectionsItems.Find(Connection.ID);
                connectionInDb.ConnectionName = Connection.ConnectionName;
                connectionInDb.ConnectionDescription = Connection.ConnectionDescription;
                connectionInDb.StarRanking = Connection.StarRanking;

                await _db.SaveChangesAsync();

                afterAddMessage = "List item updated successfully!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}