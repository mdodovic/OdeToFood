using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string  name);
        Restaurant GetById(int id);
    }
    
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Georg Pizza", Location = "London", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 3, Name = "Natural", Location = "New York", Cuisine = CuisineType.Mexican}

            };
        }
        
        public IEnumerable<Restaurant> GetRestaurantsByName(string  name)
        {
            return from r in restaurants 
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name 
                select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(restaurant => restaurant.Id == id);
        }

    }
}