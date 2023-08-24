using Microsoft.EntityFrameworkCore;
using ReviewHub.Entities;
using ReviewHub.Helpers;

namespace ReviewHub.Contexts
{
    public class ReviewHubContext : DbContext
    {
        public ReviewHubContext(DbContextOptions<ReviewHubContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EntityReviewed> EntitiesReviewed { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Review> Reviewes { get; set; }
        public DbSet<ReviewAttachments> ReviewesAttachments { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables bonds
            modelBuilder.Entity<User>()
                .HasOne<Role>(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Rank>(user => user.Rank)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Suggestion>()
                .HasOne<User>(suggestion => suggestion.User)
                .WithMany(user => user.Suggestions)
                .HasForeignKey(suggestion => suggestion.UserId);

            modelBuilder.Entity<Review>()
                .HasOne<User>(review => review.User)
                .WithMany(user => user.Reviews)
                .HasForeignKey(review => review.UserId);

            modelBuilder.Entity<Review>()
                .HasOne<EntityReviewed>(review => review.EntityReviewed)
                .WithMany(entityReviewed => entityReviewed.Reviews)
                .HasForeignKey(review => review.EntityReviewedId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReviewAttachments>()
                .HasOne<Review>(reviewAttachements => reviewAttachements.Review)
                .WithMany(review => review.Attachments)
                .HasForeignKey(reviewAttachements => reviewAttachements.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<Review>(comment => comment.Review)
                .WithMany(review => review.Comments)
                .HasForeignKey(comment => comment.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EntityReviewed>()
                .HasOne<EntityType>(review => review.EntityType)
                .WithMany(entityType => entityType.EntityRevieweds)
                .HasForeignKey(entityReviewed => entityReviewed.EntityTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region Mocking Data
                       
            modelBuilder.Entity<Rank>().HasData(
                MockEntries.GetRanksMockData()
                );

            modelBuilder.Entity<Role>().HasData(
                MockEntries.GetRolesMockData()
                );
            
            modelBuilder.Entity<User>().HasData(
                MockEntries.GetUsersMockData()
                );

            modelBuilder.Entity<EntityType>().HasData(
                MockEntries.GetEntitytypeMockData()
                );

            modelBuilder.Entity<EntityReviewed>().HasData(
                MockEntries.GetEntityReviewedsMockData()
                );

            modelBuilder.Entity<Review>().HasData(
                MockEntries.GetReviewsMockData()
                );

            modelBuilder.Entity<ReviewAttachments>().HasData(
                MockEntries.GetReviewAttachmentsMockData()
                );

            modelBuilder.Entity<Comment>().HasData(
                MockEntries.GetCommentsMockData()
                );

            modelBuilder.Entity<Suggestion>().HasData(
                MockEntries.GetSuggestionMockData()
                );             
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
