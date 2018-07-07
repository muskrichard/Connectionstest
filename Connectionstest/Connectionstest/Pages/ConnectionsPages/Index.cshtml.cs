using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connectionstest.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Connectionstest.Pages.ConnectionsPages
{
   
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string afterAddMessage { set; get; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Connections> myConnections { get; set; }


        public async Task OnGet()
        {
            myConnections = await _db.ConnectionsItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theConnection = _db.ConnectionsItems.Find(id);
            _db.ConnectionsItems.Remove(theConnection);

            await _db.SaveChangesAsync();

            afterAddMessage = "Connection deleted successfully!";

            return RedirectToPage();
        }
    }
}
        
    