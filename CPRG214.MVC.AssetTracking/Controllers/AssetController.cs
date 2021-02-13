using CPRG214.MVC.AssetTracking.Models;
using CPRG214.MVC.BLL;
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
            //Retrieves all assets from asset table.
            //var assets = AssetManager.GetAllAssets();

            ViewBag.AssetTypes = AssetTypeManager.GetAllAssetTypes();

            //Creates new AssetViewModel list.
            //var viewModels = (from asset in assets
            //                  select new AssetViewModel
            //                  {
            //                      Id = asset.Id,
            //                      AssetType = asset.AssetType.Name,
            //                      Description = asset.Description,
            //                      Manufacturer = asset.Manufacturer,
            //                      Model = asset.Model,
            //                      SerialNumber = asset.SerialNumber,
            //                      TagNumber = asset.TagNumber
            //                  }).ToList();

            return View();
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }
    }
}
