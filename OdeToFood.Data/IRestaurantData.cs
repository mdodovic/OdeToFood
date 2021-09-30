using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        
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
        
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants 
                orderby r.Name 
                select r;
        }
    }
}