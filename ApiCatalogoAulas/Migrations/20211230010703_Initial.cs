using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogoAulas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aulas",
                columns: new[] { "Id", "Data", "ModuloId", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, ".Net Core" },
                    { 2, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "C# MVC" },
                    { 3, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Web API .Net" },
                    { 4, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "React.JS" },
                    { 5, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "React Native" },
                    { 6, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Html 5 e Css 3" },
                    { 7, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kubernetes" },
                    { 8, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Cloud" }
                });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Backend" },
                    { 2, "Frontend" },
                    { 3, "Devops" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Modulos");
        }
    }
}
