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
        /// <summary>
        /// Returns a list of all asset types from the "AssetType" table within the database.
        /// </summary>
        /// <returns>List of AssetType objects.</returns>
        public static List<AssetType> GetAllAssetTypes()
        {
            var context = new AssetContext(); //Declares the database context.

            //Generates a list of all records from the database table.
            var assetTypes = (from assetType in context.AssetTypes
                          select assetType).ToList();

            return assetTypes; //Returns the list of AssetType objects.
        }

        /// <summary>
        /// Adds new AssetType record to the table "AssetType" in the database.
        /// </summary>
        /// <param name="assetType">AssetType object containing user specified information.</param>
        public static void AddAssetType(AssetType assetType) {
            var context = new AssetContext(); //Declares the database context.
            context.AssetTypes.Add(assetType); //Inserts AssetType object into the table.

            context.SaveChanges(); //Saves changes to the database context and updates the database.
        }
    }
}
