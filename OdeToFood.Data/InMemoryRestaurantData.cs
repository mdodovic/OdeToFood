﻿using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
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

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;            
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        
        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public int Commit()
        {
            return 0;
        }


    }
}