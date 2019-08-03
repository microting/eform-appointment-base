using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.AppointmentBase.Migrations
{
    public partial class RecurringAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "AppointmentVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextId",
                table: "AppointmentVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatEvery",
                table: "AppointmentVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatType",
                table: "AppointmentVersions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepeatUntil",
                table: "AppointmentVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextId",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatEvery",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepeatType",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepeatUntil",
                table: "Appointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NextId",
                table: "Appointments",
                column: "NextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Appointments_NextId",
                table: "Appointments",
                column: "NextId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Appointments_NextId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_NextId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "AppointmentVersions");

            migrationBuilder.DropColumn(
                name: "NextId",
                table: "AppointmentVersions");

            migrationBuilder.DropColumn(
                name: "RepeatEvery",
                table: "AppointmentVersions");

            migrationBuilder.DropColumn(
                name: "RepeatType",
                table: "AppointmentVersions");

            migrationBuilder.DropColumn(
                name: "RepeatUntil",
                table: "AppointmentVersions");

            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NextId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RepeatEvery",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RepeatType",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RepeatUntil",
                table: "Appointments");
        }
    }
}
