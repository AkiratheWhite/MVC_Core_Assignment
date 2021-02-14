using CPRG214.MVC.AssetTracking.Models;
using CPRG214.MVC.BLL;
using CPRG214.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVC.AssetTracking.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        /// <summary>
        /// ViewComponent initialization and creation for the Asset View page.
        /// </summary>
        /// <param name="assetTypeId">AssetTypeID used for filtering records.</param>
        /// <returns>Renders view component.</returns>
        public async Task<IViewComponentResult> InvokeAsync(int assetTypeId)
        {
            List<Asset> assets = null;//Initializes list to hold asset objects.

            /*The database does not have an ID of 0 in the "AssetType" table.
             The controller will insert a record with an ID of 0 to display all records.
             */
            if (assetTypeId == 0)
            {
                assets = AssetManager.GetAllAssets(); //Gets all assets.
            }

            else
            {
                //Gets assets that have the same AssetType ID as the argument passed to this method.
                assets = AssetManager.GetAssetsByType(assetTypeId); 
            }

            /*From the list of assets, generate a list of AssetViewModels objects that will be sent to the ViewComponent
             The list of records are going to update based on a DropDownList. The DropDownList will pass the assetTypeId to this method.
             */
            var displayAssets = (from item in assets
                                 select new AssetViewModel
                                 {
                                     AssetType = item.AssetType.Name,
                                     Description = item.Description,
                                     Id = item.Id,
                                     Manufacturer = item.Manufacturer,
                                     Model = item.Model,
                                     SerialNumber = item.SerialNumber,
                                     TagNumber = item.TagNumber
                                 });

            return View(displayAssets);
        }
    }
}
