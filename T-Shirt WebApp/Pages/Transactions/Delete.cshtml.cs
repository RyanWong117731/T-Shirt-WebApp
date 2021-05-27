﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T_Shirt_WebApp.Data;
using T_Shirt_WebApp.Models;

namespace T_Shirt_WebApp.Pages.Transactions
{
    public class DeleteModel : PageModel
    {
        private readonly T_Shirt_WebApp.Data.T_Shirt_WebAppContext _context;

        public DeleteModel(T_Shirt_WebApp.Data.T_Shirt_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = await _context.Transactions
                .Include(t => t.UserAccounts).FirstOrDefaultAsync(m => m.TransactionID == id);

            if (Transaction == null)
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

            Transaction = await _context.Transactions.FindAsync(id);

            if (Transaction != null)
            {
                _context.Transactions.Remove(Transaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
