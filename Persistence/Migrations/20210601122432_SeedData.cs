using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("774c6a20-02cc-41ee-b45b-17d74c992faa"), ".Net Core Kanalı", "DotNetCore" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b37f0c8d-3f30-42e6-9888-f59e2e4f9b5e"), "Angular Kanalı", "Angular" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("2983edbc-86f9-4683-9114-1e5d7091d874"), "React Kanalı", "React" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("2983edbc-86f9-4683-9114-1e5d7091d874"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("774c6a20-02cc-41ee-b45b-17d74c992faa"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("b37f0c8d-3f30-42e6-9888-f59e2e4f9b5e"));
        }
    }
}
