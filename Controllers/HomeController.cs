using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NicaSource.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace NicaSource.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string CurrentURL = "https://xkcd.com/info.0.json";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            BookModel lastBook = new BookModel();
            HttpResponseMessage response;
            string content;
            using (var httpClient = new HttpClient())
            {

                using (response = await httpClient.GetAsync(CurrentURL))
                {

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve content");
                    }
                    content = await response.Content.ReadAsStringAsync();
                    lastBook = JsonConvert.DeserializeObject<BookModel>(content);
                    lastBook.Last = lastBook.Num;
                }
            }

            return View(lastBook);
        }

        [HttpGet("comic/{id}")]
        public async Task<IActionResult> comic(int id)
        {
            BookModel lastBook = new BookModel();
            BookModel currentBook = new BookModel();
            HttpResponseMessage response;
            string content;
            using (var httpClient = new HttpClient())
            {

                using (response = await httpClient.GetAsync(CurrentURL))
                {

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve content");
                    }
                    content = await response.Content.ReadAsStringAsync();
                    lastBook = JsonConvert.DeserializeObject<BookModel>(content);
                    lastBook.Last = lastBook.Num;

                    if (id == 0)
                        return View("Index", lastBook);


                    int index = id;
                    while (index < lastBook.Last)
                    {
                        string url = "https://xkcd.com/" + index.ToString() + "/info.0.json";
                        using (response = await httpClient.GetAsync(url))
                        {

                            if (response.IsSuccessStatusCode)
                            {
                                content = await response.Content.ReadAsStringAsync();
                                currentBook = JsonConvert.DeserializeObject<BookModel>(content);
                                currentBook.Last = lastBook.Num;
                                return View("Index", currentBook);
                            }
                            else
                            {
                                index++;
                            }
                        }
                    }
                    throw new Exception("Cannot retrieve content");

                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
