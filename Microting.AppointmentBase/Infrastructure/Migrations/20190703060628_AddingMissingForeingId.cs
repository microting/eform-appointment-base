using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.AppointmentBase.Migrations
{
    public partial class AddingMissingForeingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentPrefillFieldValueId",
                table: "AppointmentPrefillFieldValueVersions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentPrefillFieldValueId",
                table: "AppointmentPrefillFieldValueVersions");
        }
    }
}
