using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalProjeCore.Areas.Admin.Models;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class APIMovieController : Controller
    {
        List<APIMovieViewModel> APIMovies = new List<APIMovieViewModel>();
        public async Task<IActionResult>Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
            {
                { "x-rapidapi-key", "593685335emsh51ee12e063ce1d0p18fd64jsnedd9f3e83f42" }, //imdb nin ilk 100 filmi için 
                { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" }, //imdb nin sağlayacısı
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                APIMovies = JsonConvert.DeserializeObject<List<APIMovieViewModel>>(body);
                
                Console.WriteLine(body);
                return View(APIMovies);
            }
        }
    }
}
