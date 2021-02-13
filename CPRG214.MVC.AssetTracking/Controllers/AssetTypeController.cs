using CPRG214.MVC.BLL;
using CPRG214.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVC.AssetTracking.Controllers
{
    public class AssetTypeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Asset");
        }

        public IActionResult AddAssetType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAssetType(AssetType assetType)
        {
            try
            {
                AssetTypeManager.AddAssetType(assetType);
                return RedirectToAction("Index", "Asset");
            }
            catch
            {
                return View();
            }
        }
    }
}
