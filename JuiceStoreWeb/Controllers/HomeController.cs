using JuiceStoreWeb.Models;
using JuiceStoreWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using MontyHallSimulation.Service;
using System.Diagnostics;

namespace JuiceStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFruitPressServices service;
        public HomeController(ILogger<HomeController> logger, IFruitPressServices service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            FruitPressRequest request = new FruitPressRequest();
            request = service.SetFruitPressData(request);
            return View(request);
        }

        [HttpPost]
        public IActionResult Index(FruitPressRequest request)
        {
            if (request.RecipieID > 0)
            {
                Recipie recipie = service.GetRecipie(request.RecipieID);
                List<IFruit> fruitList = new List<IFruit>();
                fruitList.AddRange(service.SetFruits(request));

                if (recipie != null)
                {
                    request.FruitPressResult = new FruitPressResult();
                    request.FruitPressResult = service.Produce(recipie, fruitList, request.MoneyPaid, request.OrderQuantity);
                }
                request = service.SetFruitPressData(request);
            }
            return View(request);
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