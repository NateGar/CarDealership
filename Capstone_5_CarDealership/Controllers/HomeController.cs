using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Capstone_5_CarDealership.Models;
using System.Net.Http;

namespace Capstone_5_CarDealership.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> search()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44317");

            var response = await client.GetAsync("/api/Car");

            var result = await response.Content.ReadAsAsync<Cars>();

            return View(result);
        }



    }
}
