using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiceoTest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class LiceoTest_113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "T_Profesores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "T_Profesores",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "T_Profesores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "T_Profesores",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Profesores",
                table: "T_Profesores",
                column: "Id");

            migrationBuilder.InsertData(
                table: "T_Profesores",
                columns: new[] { "Id", "Apellidos", "Cedula", "CreatedAt", "CreatedBy", "FechaNacimiento", "Nombres", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "Contreras Mendoza", "V-4629015", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1953, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredy Ernesto", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_T_Profesores_Cedula",
                table: "T_Profesores",
                column: "Cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Profesores",
                table: "T_Profesores");

            migrationBuilder.DropIndex(
                name: "IX_T_Profesores_Cedula",
                table: "T_Profesores");

            migrationBuilder.DeleteData(
                table: "T_Profesores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "T_Profesores",
                newName: "Profesores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "Id");
        }
    }
}
