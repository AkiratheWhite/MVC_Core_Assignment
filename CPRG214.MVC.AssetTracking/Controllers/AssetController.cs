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
        /// <summary>
        /// Index page routing.
        /// </summary>
        /// <returns>Renders the view of the index.</returns>
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

        /// <summary>
        /// ViewComponent routing.
        /// </summary>
        /// <param name="id">AssetType Id supplied to the view component for filtering.</param>
        /// <returns>Renders the view of the ViewComponent GetAssetsByType</returns>
        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        /// <summary>
        /// AddAsset page routing.
        /// </summary>
        /// <returns>Renders view of the page used to add new assets.</returns>
        public IActionResult AddAsset()
        {
            //Retrieves all assets types from AssetType table and adds to ViewBag to share with the view.
            var assetTypes = AssetTypeManager.GetAllAssetTypes();
            ViewBag.AssetTypes = assetTypes;

            return View();
        }

        /// <summary>
        /// Routing for post requests made to the server for adding new asset records.
        /// </summary>
        /// <param name="asset">Objected created and submitted by the form on the AddAssets view.</param>
        /// <returns>Inserts record and redirects user to index, or reloads if update fails.</returns>
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
                //If the update fails, reinitialize the asset types DropDownList and return the view.
                var assetTypes = AssetTypeManager.GetAllAssetTypes();
                ViewBag.AssetTypes = assetTypes;
                return View();
            }
        }

        /// <summary>
        /// Edit page routing.
        /// </summary>
        /// <param name="id">The Asset Id of the record that the user wants to modify.</param>
        /// <returns>Redirects user edit page with information from the selected record populated.</returns>
        public IActionResult Edit(int id)
        {
            //Retrieves all assets types from AssetType table and adds to ViewBag to share with the view.
            var assetTypes = AssetTypeManager.GetAllAssetTypes();
            ViewBag.AssetTypes = assetTypes;

            //Retrieves the information associated with the currently selected asset record.
            var currentAsset = AssetManager.Find(id);

            return View(currentAsset);
        }

        /// <summary>
        /// Routing for post requests made on the Edit view.
        /// </summary>
        /// <param name="asset">Objected created and submitted by the form on the Edit view</param>
        /// <returns>Updates the record information and redirects to index, or reloads page on a failed update.</returns>
        [HttpPost]
        public IActionResult Edit(Asset asset)
        {
            try
            {
                AssetManager.Update(asset); //Attempt to update the asset.
                return RedirectToAction("Index"); //Attempt to redirect.
            }
            catch
            {
                //If update fails, reinitialize the page and DropDownList.
                var assetTypes = AssetTypeManager.GetAllAssetTypes();
                ViewBag.AssetTypes = assetTypes;

                //Re-select the asset that the user was trying to edit.
                var currentAsset = AssetManager.Find(asset.Id);

                return View(currentAsset);
            }
        }
    }
}
