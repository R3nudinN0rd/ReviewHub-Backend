using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReviewHub.Migrations
{
    /// <inheritdoc />
    public partial class prodv100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReviewsAttachments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReviewsAttachments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReviewsAttachments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EntitiesReviewed",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EntitiesReviewed",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EntitiesReviewed",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EntitiesReviewed",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EntitiesReviewed",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntitiesReviewed",
                columns: new[] { "Id", "Details", "EntityTypeId", "Image" },
                values: new object[,]
                {
                    { 1, "FirstName:Remus,LastName:Ene,JobTitle:Driving Instructor", 1, null },
                    { 2, "Manufacturer:Honda,Model:Civic,Year:2015,FuelType:Petrol,UserFor:Driving Lessons", 2, null },
                    { 3, "Title:Red Rising,Author:Pierce Brown,Gender:SF", 3, null },
                    { 4, "Title:The Nun,Gender:Horror,Platform:Netflix", 4, null },
                    { 5, "Name:Endava,NumberOfEmployees:10000,Domain:IT Outsourcing", 5, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Address2", "City", "Country", "County", "CreatedDate", "DateOfBirth", "EarnedPoints", "Email", "FirstName", "Image", "LastName", "Password", "RankId", "RoleId", "Username", "VerifiedEmail" },
                values: new object[,]
                {
                    { 1, "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C6, Sc.D", "", "Pitesti", "Romania", "Arges", new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5589), new DateTime(1999, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000, "remusene69@gmail.com", "Remus", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Ene", "Lexy2806!", 6, 1, "R3nudinN0rd", true },
                    { 2, "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C7, Sc.A", "", "Pitesti", "Romania", "Arges", new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5613), new DateTime(1999, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8000, "voiculescumadalin@gmail.com", "Madalin", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Voiculescu", "ParolaMea1234!", 5, 3, "PigeonusMaximus", true },
                    { 3, "Str. Principala, Nr1", "", "Babana", "Romania", "Arges", new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5621), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000, "nicolsescurober42@gmail.com", "Robert", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Nicolescu", "ParolaMea5678!", 4, 2, "R0b1", true }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "EntityReviewedId", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, "A very good instructor", 1, 4.5, 1 },
                    { 2, "A very good car for begginer", 2, 4.0, 2 },
                    { 3, "A very good book", 3, 4.0, 3 },
                    { 4, "An acceptable movie", 4, 3.5, 1 },
                    { 5, "A bad company", 5, 0.5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Adding a new feature", "New feature", 1 },
                    { 2, "Adding a new feature 2", "New feature 2", 1 },
                    { 3, "Adding a new feature 3", "New feature 3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "ReviewId" },
                values: new object[,]
                {
                    { 1, "A short message 1", 1 },
                    { 2, "A short message 2", 1 },
                    { 3, "A short message 3", 2 },
                    { 4, "A short message 4", 3 }
                });

            migrationBuilder.InsertData(
                table: "ReviewsAttachments",
                columns: new[] { "Id", "Attachment", "ReviewId" },
                values: new object[,]
                {
                    { 1, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, 2 },
                    { 2, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, 3 },
                    { 3, new byte[] { 32, 32, 32, 32, 32, 32, 32 }, 4 }
                });
        }
    }
}
