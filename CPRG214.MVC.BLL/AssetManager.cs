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
        /// <summary>
        /// Returns all items from the table "Assets" in the database.
        /// </summary>
        /// <returns>List of Asset objects generated from records in the database.</returns>
        public static List<Asset> GetAllAssets() {
            var context = new AssetContext(); 

            //Creates a list of all records within "Asset" table, and also includes the "AssetType" navigation object.
            var assets = (from asset in context.Assets
                          orderby asset.TagNumber
                          select asset).Include(t => t.AssetType).ToList();
            
            return assets; //Returns the list of "Asset" objects.
        }

        /// <summary>
        /// Returns items from the table "Assets" in the database based on their AssetTypeId.
        /// </summary>
        /// <param name="AssetTypeId">The foreign key associated with the Asset Types on the "AssetType" table.</param>
        /// <returns>List of Asset objects generated from the records in the database that match the AssetTypeId specified.</returns>
        public static List<Asset> GetAssetsByType(int AssetTypeId)
        {
            var context = new AssetContext(); // Declares the database context.

            //Create a list of records within "Asset" table that match the AssetTypeId argument passed.
            var assets = (from asset in context.Assets
                          where asset.AssetTypeId == AssetTypeId
                          orderby asset.TagNumber
                          select asset).Include(t => t.AssetType).ToList();
            
            return assets; //Returns the list of "Asset" objects.
        }

        /// <summary>
        /// Finds a specific record in the "Asset" table of the database via AssetId (Primary key)
        /// </summary>
        /// <param name="assetId">The unique identifier (primary key) of the record.</param>
        /// <returns>Asset object for the specified record.</returns>
        public static Asset Find(int assetId)
        {
            var context = new AssetContext(); // Declares the database context.

            //Finds the record whose Id matches the user entered assetId
            var assetToSearch = (from asset in context.Assets
                                 where asset.Id == assetId
                                 select asset).SingleOrDefault();

            //Returns the Asset object.
            return assetToSearch;
        }

        /// <summary>
        /// Inserts a new record into the "Asset" table of the database.
        /// </summary>
        /// <param name="asset">Asset object containing information entered by the user.</param>
        public static void Add(Asset asset)
        {
            var context = new AssetContext(); // Declares the database context.
            context.Assets.Add(asset); //Adds the object to the database context.
            context.SaveChanges(); //Saves changes to the context, thereby updating the underlying database as well.
        }

        /// <summary>
        /// Updates a recorsd information based on information entered by the user.
        /// </summary>
        /// <param name="newAsset">Asset object containing new record information entered by the user.</param>
        public static void Update(Asset newAsset)
        {
            var context = new AssetContext(); // Declares the database context.

            //Finds the asset that the user wants to update.
            //Compares the table's records against the newAsset's Id property.
            var assetToSearch = (from asset in context.Assets
                                 where asset.Id == newAsset.Id
                                 select asset).SingleOrDefault();

            //Assigns the updated properties to the corresponding record in the database context.
            assetToSearch.AssetTypeId = newAsset.AssetTypeId;
            assetToSearch.TagNumber = newAsset.TagNumber;
            assetToSearch.Manufacturer = newAsset.Manufacturer;
            assetToSearch.Model = newAsset.Model;
            assetToSearch.Description = newAsset.Description;
            assetToSearch.SerialNumber = newAsset.SerialNumber;

            context.SaveChanges(); //Saves changes to the context and updates the underlying database.
        }
    }
}
