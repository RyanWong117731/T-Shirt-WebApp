using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T_Shirt_WebApp.Data;
using T_Shirt_WebApp.Models;

namespace T_Shirt_WebApp.Pages.T_Shirts
{
    public class EditModel : PageModel
    {
        private readonly T_Shirt_WebApp.Data.T_Shirt_WebAppContext _context;

        public EditModel(T_Shirt_WebApp.Data.T_Shirt_WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public T_Shirt T_Shirt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            T_Shirt = await _context.T_Shirts.FirstOrDefaultAsync(m => m.T_ShirtID == id);

            if (T_Shirt == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(T_Shirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_ShirtExists(T_Shirt.T_ShirtID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool T_ShirtExists(int id)
        {
            return _context.T_Shirts.Any(e => e.T_ShirtID == id);
        }
    }
}
