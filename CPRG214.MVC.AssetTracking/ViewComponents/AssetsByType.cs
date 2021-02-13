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
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;

            if (id == 0)
            {
                assets = AssetManager.GetAllAssets();
            }

            else
            {
                assets = AssetManager.GetAssetsByType(id);
            }

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
