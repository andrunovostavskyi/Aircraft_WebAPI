using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aircraft.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSomePropertiesInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_Id",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seats",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "flightId",
                table: "Seats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_flightId",
                table: "Seats",
                column: "flightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_flightId",
                table: "Seats",
                column: "flightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_flightId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_flightId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "flightId",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seats",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_Id",
                table: "Seats",
                column: "Id",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
