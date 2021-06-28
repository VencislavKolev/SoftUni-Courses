using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Data.Migrations
{
    public partial class UpdateTableDistrictsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProperties_District_DistrictId",
                table: "RealEstateProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProperties_Districts_DistrictId",
                table: "RealEstateProperties",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProperties_Districts_DistrictId",
                table: "RealEstateProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProperties_District_DistrictId",
                table: "RealEstateProperties",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
