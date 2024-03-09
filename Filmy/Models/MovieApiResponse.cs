using System.Collections.Generic;

namespace Filmy.Models
{
    public class MovieApiResponse
    {
        public List<MovieResult> Results { get; set; }
    }

    public class MovieResult
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        // You can add more properties here as needed
    }
}
