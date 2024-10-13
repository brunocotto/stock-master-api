using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaxIdToCpfAndCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxID",
                table: "Suppliers",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "Customers",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Suppliers",
                newName: "TaxID");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Customers",
                newName: "TaxId");
        }
    }
}
