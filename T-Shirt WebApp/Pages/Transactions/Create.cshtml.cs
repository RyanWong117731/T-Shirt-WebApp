using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using T_Shirt_WebApp.Data;
using T_Shirt_WebApp.Models;

namespace T_Shirt_WebApp.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly T_Shirt_WebApp.Data.T_Shirt_WebAppContext _context;

        public CreateModel(T_Shirt_WebApp.Data.T_Shirt_WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "UserAccountID");
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
