using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XeDotNet.BeerShop.WebApp.DataAccess;


namespace XeDotNet.BeerShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private BeerDatabase db;

        public HomeController(BeerDatabase db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            var beers = db.Beers;

            return View(beers);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            //db.Database.Create();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
