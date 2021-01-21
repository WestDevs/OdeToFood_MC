using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using System.Collections.Generic;

namespace Scaffolding.Pages.Restaurants
{
  public class ListModel : PageModel
  {
    private readonly IConfiguration _config;
    private readonly IRestaurantData _restaurantData;
    private readonly ILogger<ListModel> _logger;

    public IEnumerable<OdeToFood.Core.Restaurant> Restaurants { get; set; }

    [TempData]
    public string Message { get; set; }

    public string Footer { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    public ListModel(IConfiguration config, IRestaurantData restaurantData,
      ILogger<ListModel> logger)
    {
      _config = config;
      _restaurantData = restaurantData;
      _logger = logger;
    }
    public void OnGet(string searchTerm)
    {
      _logger.LogError("Executing ListModel");
      Footer = _config["Message"];

      Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
    }
  }
}
