using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MothersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDENTITY_NUMBER = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CREATION_DATE = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CUSTOMER_ID = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_CUSTOMER_ID",
                table: "ACCOUNTS",
                column: "CUSTOMER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "CUSTOMER");
        }
    }
}
