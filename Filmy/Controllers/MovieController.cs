using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;

namespace Filmy.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new RestClient("https://api.themoviedb.org/3/trending/movie/day?language=en-US");
            var request = new RestRequest("GET");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer ab3bf8e762d05382cba6eeb892b43917"); // Replace with your actual TMDB API key

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var content = response.Content;
                // Process the API response here
                Console.WriteLine(content); // For testing, you can print the response content to the console
                return Content(content);
            }
            else
            {
                // Handle API request failure
                return Content("Failed to fetch movie data from the API.");
            }
        }
    }
}
