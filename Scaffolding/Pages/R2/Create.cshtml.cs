﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Scaffolding.Pages.R2

{
  public class CreateModel : PageModel
  {
    private readonly OdeToFood.Data.OdeToFoodDbContext _context;

    public CreateModel(OdeToFood.Data.OdeToFoodDbContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public OdeToFood.Core.Restaurant Restaurant { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Restaurants.Add(Restaurant);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
