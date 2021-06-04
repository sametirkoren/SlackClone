using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PrivateChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("221ff8f4-b95f-43aa-848a-aa6a3fed2bba"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("2ea53739-5d15-40d8-906d-863f7235d1ee"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("6e5183c3-6744-462d-b658-19de6c0e4f48"));

            migrationBuilder.AddColumn<string>(
                name: "PrivateChannelId",
                table: "Channels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("31665e91-84eb-4622-80e8-d34f87b945c9"), 0, ".Net Core Kanalı", "DotNetCore", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("c20f2735-5216-4d85-abfa-47415c780685"), 0, "Angular Kanalı", "Angular", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("0500cdbe-49af-4567-978f-3c3dedd9fcdb"), 0, "React Kanalı", "React", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("0500cdbe-49af-4567-978f-3c3dedd9fcdb"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("31665e91-84eb-4622-80e8-d34f87b945c9"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("c20f2735-5216-4d85-abfa-47415c780685"));

            migrationBuilder.DropColumn(
                name: "PrivateChannelId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("2ea53739-5d15-40d8-906d-863f7235d1ee"), 0, ".Net Core Kanalı", "DotNetCore" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("221ff8f4-b95f-43aa-848a-aa6a3fed2bba"), 0, "Angular Kanalı", "Angular" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("6e5183c3-6744-462d-b658-19de6c0e4f48"), 0, "React Kanalı", "React" });
        }
    }
}
