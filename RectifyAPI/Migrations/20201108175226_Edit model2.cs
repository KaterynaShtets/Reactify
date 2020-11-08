using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactifyAPI.Migrations
{
    public partial class Editmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodPressure",
                table: "IndicatorsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "IndicatorsInfo");
        }
    }
}
