using CPRG214.MVC.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CPRG214.MVC.Data
{
    public class AssetContext:DbContext
    {
        public AssetContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        //Sets connection string to SQL Server.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLExpress;Database=AssetsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for DB created here.
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id=1, Name="Desktop Computer"},
                new AssetType { Id=2, Name="Computer Monitor"},
                new AssetType { Id=3, Name="Phone"}
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, AssetTypeId = 1, TagNumber = "AST100001", Manufacturer="Dell, Inc.", Model="3000 Series", Description="Dell Inspirion Desktop, 10th Gen.", SerialNumber="DDCWRP208S"},
                new Asset { Id = 2, AssetTypeId = 1, TagNumber = "AST100002", Manufacturer = "Hewlett-Packard", Model = "Pavilion", Description = "HP Pavilion All-in-One PC (Non-touch)", SerialNumber = "9EE87AAABL" },
                new Asset { Id = 3, AssetTypeId = 2, TagNumber = "AST200001", Manufacturer = "Acer", Model = "AOPEN", Description = "Acer AOPEN CH1 19.5\"Monitor", SerialNumber = "UMIC1AA002" },
                new Asset { Id = 4, AssetTypeId = 2, TagNumber = "AST200002", Manufacturer = "LG", Model = "UltraGear", Description = "LG UltraGear FHD HDR 24\" Monitor", SerialNumber = "24GN600-B" },
                new Asset { Id = 5, AssetTypeId = 3, TagNumber = "AST300001", Manufacturer = "Cisco", Model = "IP Phone", Description = "Cisco IP Phone 7821", SerialNumber = "CIS-7821-2" },
                new Asset { Id = 6, AssetTypeId = 3, TagNumber = "AST300002", Manufacturer = "Polycom", Model = "SoundStation2", Description = "Polycom SoundStation2 - Non-Expandable", SerialNumber = "2200-16000-001" }
                );
        }
    }
}
