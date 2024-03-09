using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Filmy.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient _httpClient;

        public MovieController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // Set base address
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            // Add headers
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ab3bf8e762d05382cba6eeb892b43917"); // Replace with your actual TMDB API key

            // Make API request
            HttpResponseMessage response = await _httpClient.GetAsync("discover/movie?api_key=ab3bf8e762d05382cba6eeb892b43917&include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc");

            if (response.IsSuccessStatusCode)
            {
                // Process successful API response
                string content = await response.Content.ReadAsStringAsync();
                // Redirect to the Result view with the API response content
                return View("Result", content);
            }
            else
            {
                // Handle API request failure
                // Redirect to the Index view when there's no connection to the API
                return RedirectToAction("Index");
            }
        }
    }
}
