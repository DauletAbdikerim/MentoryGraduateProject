using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraduateProject.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("38c43dd2-5eae-4c0e-9fce-06b55aae496b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("60771ea3-0079-45ca-9dd0-b3f164f0f73e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2d8694a-2296-4da8-8522-3852e19883dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2fd46caf-8cc8-4ec4-9d22-09812768bf72"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("601dbff3-202f-454e-8019-c11ac21e1943"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c84e336e-a571-4a79-8ad2-53f3cde86190"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0a4bb78f-a056-4e15-935e-8392d792eb3c"), "Description of a book.", "Bob", 41 },
                    { new Guid("1ff502fc-788c-4232-9ddb-cfb3415804c3"), "Description of a book.", "Sam", 24 },
                    { new Guid("747a31aa-a375-4af1-a44c-108897633048"), "Description of a book.", "Tom", 37 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("039bfedc-6ecf-443f-b8d1-544c3efd87da"), "dake", "dake" },
                    { new Guid("1e136906-4fcf-4198-888e-7268eedf9ac1"), "qwe", "qwe" },
                    { new Guid("71cd4faf-5381-4a03-9300-1423444b3e27"), "asd", "asd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0a4bb78f-a056-4e15-935e-8392d792eb3c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1ff502fc-788c-4232-9ddb-cfb3415804c3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("747a31aa-a375-4af1-a44c-108897633048"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("039bfedc-6ecf-443f-b8d1-544c3efd87da"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e136906-4fcf-4198-888e-7268eedf9ac1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("71cd4faf-5381-4a03-9300-1423444b3e27"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("38c43dd2-5eae-4c0e-9fce-06b55aae496b"), "Description of a book.", "Tom", 37 },
                    { new Guid("60771ea3-0079-45ca-9dd0-b3f164f0f73e"), "Description of a book.", "Sam", 24 },
                    { new Guid("b2d8694a-2296-4da8-8522-3852e19883dd"), "Description of a book.", "Bob", 41 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("2fd46caf-8cc8-4ec4-9d22-09812768bf72"), "dake", "dake" },
                    { new Guid("601dbff3-202f-454e-8019-c11ac21e1943"), "asd", "asd" },
                    { new Guid("c84e336e-a571-4a79-8ad2-53f3cde86190"), "qwe", "qwe" }
                });
        }
    }
}
