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
        /// <summary>
        /// Routing for index page. No index page exists for this controller, so it is routed using the AssetController's index.
        /// </summary>
        /// <returns>Redirects to the index page of AssetController.</returns>
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Asset");
        }

        /// <summary>
        /// Routing for the AddAssetType page.
        /// </summary>
        /// <returns>Renders the view for the AddAssetType page.</returns>
        public IActionResult AddAssetType()
        {
            return View();
        }

        /// <summary>
        /// Routing for post requests made on the AddAssetType page.
        /// </summary>
        /// <param name="assetType">Object generated and sent from the form on the AddAssetType page.</param>
        /// <returns>Redirect user to the index of AssetController, or reloads the page on a failure to add new record.</returns>
        [HttpPost]
        public IActionResult AddAssetType(AssetType assetType)
        {
            try
            {
                AssetTypeManager.AddAssetType(assetType); //Attempts to add new record.
                return RedirectToAction("Index", "Asset"); //Attempts to redirect to index of AssetController.
            }
            catch
            {
                return View();
            }
        }
    }
}
