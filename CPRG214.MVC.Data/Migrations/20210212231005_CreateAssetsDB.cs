using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.MVC.Data.Migrations
{
    public partial class CreateAssetsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalProperty_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Desktop Computer" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Computer Monitor" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "RentalProperty",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 1, 1, "Dell Inspirion Desktop, 10th Gen.", "Dell, Inc.", "3000 Series", "DDCWRP208S", "AST100001" },
                    { 2, 1, "HP Pavilion All-in-One PC (Non-touch)", "Hewlett-Packard", "Pavilion", "9EE87AAABL", "AST100002" },
                    { 3, 2, "Acer AOPEN CH1 19.5\"Monitor", "Acer", "AOPEN", "UMIC1AA002", "AST200001" },
                    { 4, 2, "LG UltraGear FHD HDR 24\" Monitor", "LG", "UltraGear", "24GN600-B", "AST200002" },
                    { 5, 3, "Cisco IP Phone 7821", "Cisco", "IP Phone", "CIS-7821-2", "AST300001" },
                    { 6, 3, "Polycom SoundStation2 - Non-Expandable", "Polycom", "SoundStation2", "2200-16000-001", "AST300002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_AssetTypeId",
                table: "RentalProperty",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalProperty");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
