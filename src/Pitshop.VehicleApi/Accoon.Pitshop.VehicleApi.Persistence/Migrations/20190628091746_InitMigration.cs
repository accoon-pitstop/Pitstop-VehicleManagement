using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accoon.Pitshop.VehicleApi.Persistence.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    LicenseNumber = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Type);
                    table.UniqueConstraint("AK_Vehicles_Brand", x => x.Brand);
                    table.UniqueConstraint("AK_Vehicles_Id", x => x.Id);
                    table.UniqueConstraint("AK_Vehicles_LicenseNumber", x => x.LicenseNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
