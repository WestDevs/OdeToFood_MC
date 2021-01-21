using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace Scaffolding.Pages.Restaurants
{
  public class DeleteModel : PageModel
  {
    private readonly IRestaurantData _restaurantData;
    public OdeToFood.Core.Restaurant Restaurant { get; set; }
    public DeleteModel(IRestaurantData restaurantData)
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

    public IActionResult OnPost(int restaurantId)
    {
      Restaurant = _restaurantData.Delete(restaurantId);
      if (Restaurant != null)
      {
        TempData["Message"] = $@"Successfully deleted {Restaurant.Name}!";
        _restaurantData.Commit();
      }
      else
      {
        return RedirectToPage("./NotFound");
      }
      return RedirectToPage("./List");

    }
  }
}
