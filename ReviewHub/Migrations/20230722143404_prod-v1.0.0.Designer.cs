﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewHub.Contexts;

#nullable disable

namespace ReviewHub.Migrations
{
    [DbContext(typeof(ReviewHubContext))]
    [Migration("20230722143404_prod-v1.0.0")]
    partial class prodv100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReviewHub.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ReviewHub.Entities.EntityReviewed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("EntitiesReviewed");
                });

            modelBuilder.Entity("ReviewHub.Entities.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This type is represented by the person entries like uber drivers.",
                            Title = "Person"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This entity type is defined by car entries.",
                            Title = "Car"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This entity type is defined by book entries.",
                            Title = "Book"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This entity type is defined by movie entries.",
                            Title = "Movie"
                        },
                        new
                        {
                            Id = 5,
                            Description = "This entity type is defined by company entries.",
                            Title = "Companies"
                        });
                });

            modelBuilder.Entity("ReviewHub.Entities.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumAmountOfPoints")
                        .HasColumnType("int");

                    b.Property<int>("MinimumAmountOfPoints")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ranks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Starting rank. A user has Bronze rank if the total points aquired value is between 0 and 499.",
                            MaximumAmountOfPoints = 499,
                            MinimumAmountOfPoints = 0,
                            Title = "Bronze"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Second rank. A user has Silver rank if the total points aquired value is between 500 and 1 499.",
                            MaximumAmountOfPoints = 1499,
                            MinimumAmountOfPoints = 500,
                            Title = "Silver"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Third rank. A user has Gold rank if the total points aquired value is between 1 500 and 3 999.",
                            MaximumAmountOfPoints = 3999,
                            MinimumAmountOfPoints = 1500,
                            Title = "Gold"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fourth rank. A user has Platinum rank if the total points aquired value is between 4 000 and 7 999.",
                            MaximumAmountOfPoints = 7999,
                            MinimumAmountOfPoints = 4000,
                            Title = "Platinum"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Fifth rank. A user has Diamond rank if the total points aquired value is between 8 000 and 15 999.",
                            MaximumAmountOfPoints = 15999,
                            MinimumAmountOfPoints = 8000,
                            Title = "Diamond"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Sixth rank. A user has Hero I rank if the total points aquired value is between 16 000 and 31 999.",
                            MaximumAmountOfPoints = 31999,
                            MinimumAmountOfPoints = 16000,
                            Title = "Hero I"
                        });
                });

            modelBuilder.Entity("ReviewHub.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityReviewedId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityReviewedId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ReviewHub.Entities.ReviewAttachments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Attachment")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("ReviewsAttachments");
                });

            modelBuilder.Entity("ReviewHub.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This role have full application access. It can create admin users.",
                            Title = "Owner"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This role don't have permission to create new admins. Unless this aspect, it have access to use all features.",
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This role can add new person entities that agreed GDPR.",
                            Title = "Contributor"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This role ca add non-person entities, reviews, comments and anything else without affecting other users.",
                            Title = "User"
                        },
                        new
                        {
                            Id = 5,
                            Description = "This role only have reading access.",
                            Title = "Guest"
                        });
                });

            modelBuilder.Entity("ReviewHub.Entities.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("ReviewHub.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("EarnedPoints")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VerifiedEmail")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReviewHub.Entities.Comment", b =>
                {
                    b.HasOne("ReviewHub.Entities.Review", "Review")
                        .WithMany("Comments")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ReviewHub.Entities.EntityReviewed", b =>
                {
                    b.HasOne("ReviewHub.Entities.EntityType", "EntityType")
                        .WithMany("EntityRevieweds")
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityType");
                });

            modelBuilder.Entity("ReviewHub.Entities.Review", b =>
                {
                    b.HasOne("ReviewHub.Entities.EntityReviewed", "EntityReviewed")
                        .WithMany("Reviews")
                        .HasForeignKey("EntityReviewedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewHub.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityReviewed");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReviewHub.Entities.ReviewAttachments", b =>
                {
                    b.HasOne("ReviewHub.Entities.Review", "Review")
                        .WithMany("Attachments")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ReviewHub.Entities.Suggestion", b =>
                {
                    b.HasOne("ReviewHub.Entities.User", "User")
                        .WithMany("Suggestions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReviewHub.Entities.User", b =>
                {
                    b.HasOne("ReviewHub.Entities.Rank", "Rank")
                        .WithMany("Users")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReviewHub.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rank");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ReviewHub.Entities.EntityReviewed", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ReviewHub.Entities.EntityType", b =>
                {
                    b.Navigation("EntityRevieweds");
                });

            modelBuilder.Entity("ReviewHub.Entities.Rank", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ReviewHub.Entities.Review", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ReviewHub.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ReviewHub.Entities.User", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Suggestions");
                });
#pragma warning restore 612, 618
        }
    }
}
