using CPRG214.MVC.AssetTracking.Models;
using CPRG214.MVC.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVC.AssetTracking.Controllers
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
            //Retrieves all assets from asset table.
            var assets = AssetManager.GetAllAssets();

            //Creates new AssetViewModel list.
            var viewModels = (from asset in assets
                              select new AssetViewModel
                              {
                                  AssetType = asset.AssetType.Name,
                                  Description = asset.Description,
                                  Manufacturer = asset.Manufacturer,
                                  Model = asset.Model,
                                  SerialNumber = asset.SerialNumber,
                                  TagNumber = asset.TagNumber
                              }).ToList();

            return View(viewModels);
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
