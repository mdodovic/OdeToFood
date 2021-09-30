using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        
        public List(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }


        public void OnGet()
        {
            Message = "Hello everybody!";
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}