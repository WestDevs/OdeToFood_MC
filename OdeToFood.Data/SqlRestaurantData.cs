using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
  public class SqlRestaurantData : IRestaurantData
  {
    private readonly OdeToFoodDbContext _dbContext;

    public SqlRestaurantData(OdeToFoodDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public IEnumerable<Restaurant> GetRestaurantByName(string name)
    {
      var query = from r in _dbContext.Restaurants
                  where r.Name.StartsWith(name) || string.IsNullOrWhiteSpace(name)
                  orderby r.Name
                  select r;
      return query;
    }

    public Restaurant GetById(int id)
    {
      return _dbContext.Restaurants.Find(id);
    }

    public Restaurant Update(Restaurant updatedRestaurant)
    {
      var entity = _dbContext.Restaurants.Attach(updatedRestaurant);
      entity.State = EntityState.Modified;
      return updatedRestaurant;
    }

    public Restaurant Add(Restaurant newRestaurant)
    {
      _dbContext.Add(newRestaurant);
      return newRestaurant;

    }

    public Restaurant Delete(int id)
    {
      var restaurant = GetById(id);
      if (restaurant != null)
      {
        _dbContext.Restaurants.Remove(restaurant);
      }

      return restaurant;
    }

    public int GetCountOfRestaurants()
    {
      return _dbContext.Restaurants.Count();
    }

    public int Commit()
    {
      return _dbContext.SaveChanges();
    }
  }
}