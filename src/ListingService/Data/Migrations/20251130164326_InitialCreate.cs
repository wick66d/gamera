using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListingService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameName = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PriceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    IsStackable = table.Column<bool>(type: "boolean", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    DeliveryType = table.Column<byte>(type: "smallint", nullable: false),
                    MinDeliveryMinutes = table.Column<int>(type: "integer", nullable: true),
                    MaxDeliveryMinutes = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
