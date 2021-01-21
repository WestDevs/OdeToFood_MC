using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace Scaffolding.Pages.Restaurants
{
  public class DetailModel : PageModel
  {
    private readonly IRestaurantData _restaurantData;

    [TempData]
    public string Message { get; set; }
    public OdeToFood.Core.Restaurant Restaurant { get; set; }

    public DetailModel(IRestaurantData restaurantData)
    {
      _restaurantData = restaurantData;
    }
    public IActionResult OnGet(int restaurantId)
    {
      Restaurant = _restaurantData.GetById(restaurantId);
      if (Restaurant == null)
      {
        return RedirectToPage("./NotFound");
      }
      return Page();
    }
  }
}
