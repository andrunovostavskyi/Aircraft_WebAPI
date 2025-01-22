using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aircraft.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Trips\" ALTER COLUMN \"TimeDeparture\" SET DATA TYPE interval USING (\"TimeDeparture\" - '0001-01-01'::timestamp)");
            migrationBuilder.Sql("ALTER TABLE \"Trips\" ALTER COLUMN \"TimeArrival\" SET DATA TYPE interval USING (\"TimeArrival\" - '0001-01-01'::timestamp)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeDeparture",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeArrival",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }
    }
}
