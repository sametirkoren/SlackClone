using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddTyping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TypingNotification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypingNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypingNotification_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypingNotification_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("127994f5-34ae-4a12-b812-36d584d9c2a4"), 0, ".Net Core Kanalı", "DotNetCore", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("219410ee-4854-42ab-8c72-c8981372ea75"), 0, "Angular Kanalı", "Angular", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("3935400a-3bc1-4ea5-91d9-365828b3d675"), 0, "React Kanalı", "React", null });

            migrationBuilder.CreateIndex(
                name: "IX_TypingNotification_ChannelId",
                table: "TypingNotification",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypingNotification");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("127994f5-34ae-4a12-b812-36d584d9c2a4"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("219410ee-4854-42ab-8c72-c8981372ea75"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("3935400a-3bc1-4ea5-91d9-365828b3d675"));

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
    }
}
