using CPRG214.MVC.Data;
using CPRG214.MVC.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.MVC.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAllAssets() {
            var context = new AssetContext();
            var assets = (from asset in context.Assets
                          select asset).Include(t => t.AssetType).ToList();
            return assets;
        }

        public static List<Asset> GetAssetsByType(int AssetTypeId)
        {
            var context = new AssetContext();
            var assets = (from asset in context.Assets
                          where asset.AssetTypeId == AssetTypeId
                          select asset).Include(t => t.AssetType).ToList();
            return assets;
        }
    }
}
