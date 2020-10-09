/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.AppointmentBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider

            var appointmentAutoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object appointmentAutoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                appointmentAutoIdGenStrategy = "MySql:ValueGenerationStrategy";
                appointmentAutoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "AppointmentPrefillFieldValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AppointmentId = table.Column<int>(nullable: true),
                    MicrotingSiteUid = table.Column<int>(),
                    FieldId = table.Column<int>(),
                    FieldValue = table.Column<string>(nullable: true),
                    AppointmentFvId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPrefillFieldValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    GlobalId = table.Column<string>(nullable: true),
                    StartAt = table.Column<DateTime>(nullable: true),
                    ExpireAt = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(maxLength: 255, nullable: true),
                    ProcessingState = table.Column<string>(maxLength: 255, nullable: true),
                    Body = table.Column<string>(nullable: true),
                    ExceptionString = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Info = table.Column<string>(nullable: true),
                    MicrotingUuid = table.Column<string>(maxLength: 255, nullable: true),
                    Completed = table.Column<short>(nullable: true),
                    Replacements = table.Column<string>(nullable: true),
                    SdkeFormId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    ColorRule = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSiteVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AppointmentId = table.Column<int>(nullable: true),
                    MicrotingSiteUid = table.Column<int>(),
                    ExceptionString = table.Column<string>(nullable: true),
                    SdkCaseId = table.Column<string>(maxLength: 255, nullable: true),
                    ProcessingState = table.Column<string>(maxLength: 255, nullable: true),
                    Completed = table.Column<short>(nullable: true),
                    AppointmentSiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSiteVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AppointmentId = table.Column<int>(nullable: true),
                    GlobalId = table.Column<string>(nullable: true),
                    StartAt = table.Column<DateTime>(nullable: true),
                    ExpireAt = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(maxLength: 255, nullable: true),
                    ProcessingState = table.Column<string>(maxLength: 255, nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    Body = table.Column<string>(nullable: true),
                    ExceptionString = table.Column<string>(nullable: true),
                    SiteIds = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Info = table.Column<string>(nullable: true),
                    MicrotingUid = table.Column<string>(maxLength: 255, nullable: true),
                    Connected = table.Column<short>(nullable: true),
                    Completed = table.Column<short>(nullable: true),
                    Replacements = table.Column<string>(nullable: true),
                    SdkeFormId = table.Column<int>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    ColorRule = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentPrefillFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AppointmentId = table.Column<int>(nullable: true),
                    MicrotingSiteUid = table.Column<int>(),
                    FieldId = table.Column<int>(),
                    FieldValue = table.Column<string>(nullable: true),
                    AppointmentFvId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPrefillFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentPrefillFieldValues_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSites",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    AppointmentId = table.Column<int>(nullable: true),
                    MicrotingSiteUid = table.Column<int>(),
                    ExceptionString = table.Column<string>(nullable: true),
                    SdkCaseId = table.Column<string>(maxLength: 255, nullable: true),
                    ProcessingState = table.Column<string>(maxLength: 255, nullable: true),
                    Completed = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentSites_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPrefillFieldValues_AppointmentId",
                table: "AppointmentPrefillFieldValues",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSites_AppointmentId",
                table: "AppointmentSites",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentPrefillFieldValues");

            migrationBuilder.DropTable(
                name: "AppointmentPrefillFieldValueVersions");

            migrationBuilder.DropTable(
                name: "AppointmentSites");

            migrationBuilder.DropTable(
                name: "AppointmentSiteVersions");

            migrationBuilder.DropTable(
                name: "AppointmentVersions");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
