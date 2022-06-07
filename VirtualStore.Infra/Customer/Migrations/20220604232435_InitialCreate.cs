using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualStore.Infra.Customer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    State = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PublicPlace = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Active = table.Column<bool>(type: "bit", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CPF",
                table: "Customer",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
