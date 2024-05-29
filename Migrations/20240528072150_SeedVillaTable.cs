using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dontnetstarter.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "id", "amenity", "created_at", "details", "imageurl", "name", "occupancy", "rate", "sqft", "updated_at" },
                values: new object[,]
                {
                    { 1, "Pool, Ocean View, Wi-Fi", new DateTime(2023, 11, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6210), "A luxurious villa with ocean views and a private pool.", "https://example.com/images/luxury_villa.jpg", "Luxury Villa", 8, 500.0, 3000, new DateTime(2024, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6230) },
                    { 2, "Fireplace, Garden View, Wi-Fi", new DateTime(2023, 9, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6240), "A quaint cottage perfect for a romantic getaway.", "https://example.com/images/cozy_cottage.jpg", "Cozy Cottage", 2, 150.0, 800, new DateTime(2024, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6240) },
                    { 3, "Gym, City View, Wi-Fi", new DateTime(2024, 2, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6250), "A stylish apartment in the heart of the city.", "https://example.com/images/modern_apartment.jpg", "Modern Apartment", 4, 200.0, 1200, new DateTime(2024, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6250) },
                    { 4, "Hiking Trails, Fireplace, Wi-Fi", new DateTime(2023, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6250), "A secluded cabin in the woods for a nature retreat.", "https://example.com/images/rustic_cabin.jpg", "Rustic Cabin", 4, 180.0, 1000, new DateTime(2024, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6250) },
                    { 5, "Beach Access, Ocean View, Wi-Fi", new DateTime(2024, 1, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6250), "A charming bungalow with direct beach access.", "https://example.com/images/beachfront_bungalow.jpg", "Beachfront Bungalow", 6, 300.0, 1500, new DateTime(2024, 5, 28, 8, 21, 50, 204, DateTimeKind.Local).AddTicks(6260) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
