using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using eKart.Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace eKart.web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IConfiguration _configuration;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetStringAsync(_configuration["ApiEndpoint"]);
                var product = JsonConvert.DeserializeObject<List<Product>>(result);
                return View(product);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
