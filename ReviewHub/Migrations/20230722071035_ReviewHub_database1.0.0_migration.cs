using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReviewHub.Migrations
{
    /// <inheritdoc />
    public partial class ReviewHub_database100_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumAmountOfPoints = table.Column<int>(type: "int", nullable: false),
                    MaximumAmountOfPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntitiesReviewed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntitiesReviewed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntitiesReviewed_Categories_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedEmail = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarnedPoints = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EntityReviewedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_EntitiesReviewed_EntityReviewedId",
                        column: x => x.EntityReviewedId,
                        principalTable: "EntitiesReviewed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsAttachments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "This type is represented by the person entries like uber drivers.", "Person" },
                    { 2, "This entity type is defined by car entries.", "Car" },
                    { 3, "This entity type is defined by book entries.", "Book" },
                    { 4, "This entity type is defined by movie entries.", "Movie" },
                    { 5, "This entity type is defined by company entries.", "Companies" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Description", "MaximumAmountOfPoints", "MinimumAmountOfPoints", "Title" },
                values: new object[,]
                {
                    { 1, "Starting rank. A user has Bronze rank if the total points aquired value is between 0 and 499.", 499, 0, "Bronze" },
                    { 2, "Second rank. A user has Silver rank if the total points aquired value is between 500 and 1 499.", 1499, 500, "Silver" },
                    { 3, "Third rank. A user has Gold rank if the total points aquired value is between 1 500 and 3 999.", 3999, 1500, "Gold" },
                    { 4, "Fourth rank. A user has Platinum rank if the total points aquired value is between 4 000 and 7 999.", 7999, 4000, "Platinum" },
                    { 5, "Fifth rank. A user has Diamond rank if the total points aquired value is between 8 000 and 15 999.", 15999, 8000, "Diamond" },
                    { 6, "Sixth rank. A user has Hero I rank if the total points aquired value is between 16 000 and 31 999.", 31999, 16000, "Hero I" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "This role have full application access. It can create admin users.", "Owner" },
                    { 2, "This role don't have permission to create new admins. Unless this aspect, it have access to use all features.", "Admin" },
                    { 3, "This role can add new person entities that agreed GDPR.", "Contributor" },
                    { 4, "This role ca add non-person entities, reviews, comments and anything else without affecting other users.", "User" },
                    { 5, "This role only have reading access.", "Guest" }
                });

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
                    { 1, "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C6, Sc.D", "", "Pitesti", "Romania", "Arges", new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5741), new DateTime(1999, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000, "remusene69@gmail.com", "Remus", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Ene", "Lexy2806!", 6, 1, "R3nudinN0rd", true },
                    { 2, "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C7, Sc.A", "", "Pitesti", "Romania", "Arges", new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5767), new DateTime(1999, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8000, "voiculescumadalin@gmail.com", "Madalin", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Voiculescu", "ParolaMea1234!", 5, 3, "PigeonusMaximus", true },
                    { 3, "Str. Principala, Nr1", "", "Babana", "Romania", "Arges", new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5776), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000, "nicolsescurober42@gmail.com", "Robert", new byte[] { 32, 32, 32, 32, 32, 32, 32 }, "Nicolescu", "ParolaMea5678!", 4, 2, "R0b1", true }
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_EntitiesReviewed_EntityTypeId",
                table: "EntitiesReviewed",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EntityReviewedId",
                table: "Reviews",
                column: "EntityReviewedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsAttachments_ReviewId",
                table: "ReviewsAttachments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RankId",
                table: "Users",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ReviewsAttachments");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "EntitiesReviewed");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
