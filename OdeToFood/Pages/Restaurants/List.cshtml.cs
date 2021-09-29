using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OdeToFood.Pages.Restaurants
{
    public class List : PageModel
    {
        
        public string Message { get; set; }
        
        public void OnGet()
        {
            Message = "Hello, World!";
        }
    }
}