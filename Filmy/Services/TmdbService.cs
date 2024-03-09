using System;
using System.Net.Http;
using System.Threading.Tasks;
using Filmy.Models;
using Newtonsoft.Json;

namespace Filmy.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "ab3bf8e762d05382cba6eeb892b43917";

        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Movie> GetRandomMovieAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/${{params.id}}?language=en-US&api_key=${{ab3bf8e762d05382cba6eeb892b43917}}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var movieApiResponse = JsonConvert.DeserializeObject<MovieApiResponse>(content);

                // Select a random movie from the list
                var random = new Random();
                var index = random.Next(0, movieApiResponse.Results.Count);
                var selectedMovie = movieApiResponse.Results[index];

                // Map the selected movie to the Movie model
                var movie = new Movie
                {
                    Title = selectedMovie.Title,
                    Overview = selectedMovie.Overview
                    // You can add more properties here as needed
                };

                return movie;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                throw new Exception("Error occurred while fetching movie information.", ex);
            }
        }
    }
}
