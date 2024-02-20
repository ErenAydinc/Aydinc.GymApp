using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalTrainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "PersonalTrainers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "PersonalTrainers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "PersonalTrainers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "PersonalTrainers.Add");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "PersonalTrainers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "PersonalTrainers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "OperationClaims.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "OperationClaims.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "OperationClaims.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "OperationClaims.Add");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 171, 99, 232, 140, 49, 5, 220, 19, 46, 168, 39, 11, 188, 72, 25, 13, 208, 12, 74, 55, 55, 167, 121, 203, 156, 15, 7, 100, 106, 212, 83, 119, 81, 245, 114, 39, 212, 10, 70, 189, 43, 204, 129, 9, 97, 147, 65, 122, 123, 16, 18, 141, 168, 89, 16, 135, 83, 172, 16, 218, 60, 194, 190, 21 }, new byte[] { 181, 193, 8, 68, 235, 17, 106, 80, 98, 225, 154, 61, 35, 86, 217, 84, 133, 10, 196, 29, 215, 170, 55, 17, 158, 51, 75, 251, 200, 203, 2, 169, 159, 116, 32, 173, 158, 113, 237, 113, 124, 72, 101, 43, 105, 120, 243, 88, 85, 203, 221, 238, 232, 179, 166, 243, 168, 66, 38, 210, 98, 152, 82, 172, 73, 120, 243, 157, 254, 79, 39, 0, 197, 78, 214, 7, 131, 142, 53, 34, 105, 52, 7, 238, 72, 143, 76, 72, 158, 120, 22, 140, 135, 61, 46, 221, 186, 163, 214, 49, 33, 58, 74, 30, 24, 24, 151, 253, 100, 122, 142, 125, 212, 228, 108, 127, 147, 195, 174, 223, 87, 117, 213, 164, 41, 238, 12, 49 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTrainer");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "OperationClaims.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "OperationClaims.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "OperationClaims.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "OperationClaims.Add");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "OperationClaims.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "OperationClaims.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Auth.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Auth.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Auth.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Auth.RevokeToken");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 146, 80, 142, 243, 205, 169, 235, 10, 45, 126, 1, 160, 31, 206, 36, 251, 254, 41, 61, 138, 140, 178, 46, 106, 109, 129, 167, 0, 111, 71, 69, 32, 191, 207, 66, 190, 118, 184, 110, 189, 16, 17, 53, 43, 110, 32, 220, 159, 19, 67, 160, 70, 128, 159, 7, 84, 118, 115, 156, 151, 29, 122, 13 }, new byte[] { 253, 217, 56, 184, 40, 36, 125, 205, 203, 109, 220, 155, 213, 235, 81, 106, 169, 196, 10, 200, 242, 134, 0, 242, 81, 159, 81, 254, 105, 61, 59, 81, 65, 169, 26, 82, 44, 47, 153, 157, 7, 38, 167, 148, 255, 58, 5, 169, 244, 78, 56, 150, 192, 43, 245, 120, 186, 75, 235, 154, 69, 155, 10, 168, 87, 146, 148, 5, 255, 204, 43, 60, 165, 83, 121, 216, 182, 30, 93, 52, 211, 177, 87, 244, 36, 155, 61, 173, 105, 82, 128, 55, 155, 94, 208, 101, 172, 126, 98, 19, 27, 192, 54, 86, 4, 44, 128, 55, 45, 108, 60, 243, 223, 195, 14, 197, 181, 223, 139, 225, 141, 113, 229, 160, 250, 195, 121, 62 } });
        }
    }
}
