using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericDataPointHandlingDemo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SensorType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SensorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataPointType = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterOne = table.Column<int>(type: "INTEGER", nullable: true),
                    ConcreteSensorTypeTwoDataPoint_ParameterOne = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPoints_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SensorId = table.Column<int>(type: "INTEGER", nullable: false),
                    LowThresholdValue = table.Column<double>(type: "REAL", nullable: true),
                    HighThresholdValue = table.Column<double>(type: "REAL", nullable: true),
                    ThresholdType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thresholds_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TriggeredThresholds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThresholdId = table.Column<int>(type: "INTEGER", nullable: false),
                    TriggeringValue = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggeredThresholds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriggeredThresholds_Thresholds_ThresholdId",
                        column: x => x.ThresholdId,
                        principalTable: "Thresholds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Name", "SensorType" },
                values: new object[] { 1, "First Sensor", 0 });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Name", "SensorType" },
                values: new object[] { 2, "Second Sensor", 1 });

            migrationBuilder.InsertData(
                table: "Thresholds",
                columns: new[] { "Id", "HighThresholdValue", "LowThresholdValue", "SensorId", "ThresholdType" },
                values: new object[] { 1, 90.0, 50.0, 1, 100 });

            migrationBuilder.InsertData(
                table: "Thresholds",
                columns: new[] { "Id", "HighThresholdValue", "LowThresholdValue", "SensorId", "ThresholdType" },
                values: new object[] { 2, 90.0, 50.0, 2, 200 });

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_SensorId",
                table: "DataPoints",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Thresholds_SensorId",
                table: "Thresholds",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_TriggeredThresholds_ThresholdId",
                table: "TriggeredThresholds",
                column: "ThresholdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPoints");

            migrationBuilder.DropTable(
                name: "TriggeredThresholds");

            migrationBuilder.DropTable(
                name: "Thresholds");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
