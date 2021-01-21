﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Scaffolding.Pages.R2
{
  public class DeleteModel : PageModel
  {
    private readonly OdeToFood.Data.OdeToFoodDbContext _context;

    public DeleteModel(OdeToFood.Data.OdeToFoodDbContext context)
    {
      _context = context;
    }

    [BindProperty]
    public OdeToFood.Core.Restaurant Restaurant { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

      if (Restaurant == null)
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

      Restaurant = await _context.Restaurants.FindAsync(id);

      if (Restaurant != null)
      {
        _context.Restaurants.Remove(Restaurant);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
