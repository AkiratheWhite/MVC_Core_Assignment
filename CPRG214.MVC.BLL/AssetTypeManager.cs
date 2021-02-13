using CPRG214.MVC.Data;
using CPRG214.MVC.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.MVC.BLL
{
    public class AssetTypeManager
    {
        public static List<AssetType> GetAllAssetTypes()
        {
            var context = new AssetContext();
            var assetTypes = (from assetType in context.AssetTypes
                          select assetType).ToList();

            return assetTypes;

        }

        public static void AddAssetType(AssetType assetType) {
            var context = new AssetContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }
    }
}
