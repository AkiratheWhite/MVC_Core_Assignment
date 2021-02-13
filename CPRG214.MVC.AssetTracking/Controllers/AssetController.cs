using CPRG214.MVC.AssetTracking.Models;
using CPRG214.MVC.BLL;
using CPRG214.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVC.AssetTracking.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            //Retrieves all assets types from AssetType table.
            var assetTypes = AssetTypeManager.GetAllAssetTypes();

            //Adds a new AssetType at index 0 with an Id of 0 so that we can show all AssetTypes.
            assetTypes.Insert(0, new Domain.AssetType { Id = 0, Name = "All Types" });

            //Stores information in a ViewBag to be shared with the view.
            ViewBag.AssetTypes = assetTypes;
            return View();
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        public IActionResult AddAsset()
        {
            var assetTypes = AssetTypeManager.GetAllAssetTypes();
            ViewBag.AssetTypes = assetTypes;

            return View();
        }

        [HttpPost]
        public IActionResult AddAsset(Asset asset)
        {
            try
            {
                //Attempt to add the new object to the database context.
                AssetManager.Add(asset);
                //If the update is successful, redirect to index.
                return RedirectToAction("Index");
            }

            catch
            {
                var assetTypes = AssetTypeManager.GetAllAssetTypes();
                ViewBag.AssetTypes = assetTypes;
                return View();
            }
        }
    }
}
