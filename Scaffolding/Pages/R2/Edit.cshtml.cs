using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Pages.R2
{
  public class EditModel : PageModel
  {
    private readonly OdeToFood.Data.OdeToFoodDbContext _context;

    public EditModel(OdeToFood.Data.OdeToFoodDbContext context)
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Restaurant).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RestaurantExists(Restaurant.Id))
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

    private bool RestaurantExists(int id)
    {
      return _context.Restaurants.Any(e => e.Id == id);
    }
  }
}
