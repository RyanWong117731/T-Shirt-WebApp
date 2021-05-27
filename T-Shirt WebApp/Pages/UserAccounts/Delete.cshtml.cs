using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T_Shirt_WebApp.Data;
using T_Shirt_WebApp.Models;

namespace T_Shirt_WebApp.Pages.UserAccounts
{
    public class DeleteModel : PageModel
    {
        private readonly T_Shirt_WebApp.Data.T_Shirt_WebAppContext _context;

        public DeleteModel(T_Shirt_WebApp.Data.T_Shirt_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccounts.FirstOrDefaultAsync(m => m.UserAccountID == id);

            if (UserAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAccount = await _context.UserAccounts.FindAsync(id);

            if (UserAccount != null)
            {
                _context.UserAccounts.Remove(UserAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
