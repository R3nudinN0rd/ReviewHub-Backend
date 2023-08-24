using ReviewHub.Entities;

namespace ReviewHub.Helpers
{
    public static class MockEntries
    {
        public static List<Role> GetRolesMockData()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Title = "Owner",
                    Description = "This role have full application access. It can create admin users.",
                },
                new Role()
                {
                    Id = 2,
                    Title = "Admin",
                    Description = "This role don't have permission to create new admins. Unless this aspect, it have access to use all features."
                },
                new Role()
                {
                    Id = 3,
                    Title = "Contributor",
                    Description = "This role can add new person entities that agreed GDPR."
                },
                new Role()
                {
                    Id = 4,
                    Title = "User",
                    Description = "This role ca add non-person entities, reviews, comments and anything else without affecting other users."
                },
                new Role()
                {
                    Id = 5,
                    Title = "Guest",
                    Description = "This role only have reading access."
                }
            };
        }
        public static List<Rank> GetRanksMockData()
        {
            return new List<Rank>()
            {
                new Rank()
                {
                    Id=1,
                    Title = "Bronze",
                    Description = "Starting rank. A user has Bronze rank if the total points aquired value is between 0 and 499.",
                    MinimumAmountOfPoints = 0,
                    MaximumAmountOfPoints = 499
                },
                new Rank()
                {
                    Id=2,
                    Title = "Silver",
                    Description = "Second rank. A user has Silver rank if the total points aquired value is between 500 and 1 499.",
                    MinimumAmountOfPoints = 500,
                    MaximumAmountOfPoints = 1499
                },
                new Rank()
                {
                    Id = 3,
                    Title = "Gold",
                    Description = "Third rank. A user has Gold rank if the total points aquired value is between 1 500 and 3 999.",
                    MinimumAmountOfPoints = 1500,
                    MaximumAmountOfPoints = 3999
                },
                new Rank()
                {
                    Id = 4,
                    Title = "Platinum",
                    Description = "Fourth rank. A user has Platinum rank if the total points aquired value is between 4 000 and 7 999.",
                    MinimumAmountOfPoints = 4000,
                    MaximumAmountOfPoints = 7999
                },
                new Rank()
                {
                    Id = 5,
                    Title = "Diamond",
                    Description = "Fifth rank. A user has Diamond rank if the total points aquired value is between 8 000 and 15 999.",
                    MinimumAmountOfPoints = 8000,
                    MaximumAmountOfPoints = 15999
                },
                new Rank()
                {
                    Id = 6,
                    Title = "Hero I",
                    Description = "Sixth rank. A user has Hero I rank if the total points aquired value is between 16 000 and 31 999.",
                    MinimumAmountOfPoints = 16000,
                    MaximumAmountOfPoints = 31999
                }
            };
        }
        public static List<User> GetUsersMockData()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Remus",
                    LastName = "Ene",
                    Username = "R3nudinN0rd",
                    Email = "remusene69@gmail.com",
                    VerifiedEmail = true,
                    Password = "Lexy2806!",
                    DateOfBirth = new DateTime(day:28, month: 06, year: 1999),
                    CreatedDate = DateTime.Now,
                    Address = "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C6, Sc.D",
                    Address2 = "",
                    Country = "Romania",
                    County = "Arges",
                    City = "Pitesti",
                    EarnedPoints = 16000,
                    Image = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    RankId = 6,
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Madalin",
                    LastName = "Voiculescu",
                    Username = "PigeonusMaximus",
                    Email = "voiculescumadalin@gmail.com",
                    VerifiedEmail = true,
                    Password = "ParolaMea1234!",
                    DateOfBirth = new DateTime(day:4, month: 11, year: 1999),
                    CreatedDate = DateTime.Now,
                    Address = "Str. Doctor Stefan Odobleja, Nr. 2 Bl. C7, Sc.A",
                    Address2 = "",
                    Country = "Romania",
                    County = "Arges",
                    City = "Pitesti",
                    EarnedPoints = 8000,
                    Image = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    RankId = 5,
                    RoleId = 3
                },
                 new User()
                {
                    Id = 3,
                    FirstName = "Robert",
                    LastName = "Nicolescu",
                    Username = "R0b1",
                    Email = "nicolsescurober42@gmail.com",
                    VerifiedEmail = true,
                    Password = "ParolaMea5678!",
                    DateOfBirth = new DateTime(day:12, month: 12, year: 1999),
                    CreatedDate = DateTime.Now,
                    Address = "Str. Principala, Nr1",
                    Address2 = "",
                    Country = "Romania",
                    County = "Arges",
                    City = "Babana",
                    EarnedPoints = 4000,
                    Image = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    RankId = 4,
                    RoleId = 2
                }
            };
        }
        public static List<EntityType> GetEntitytypeMockData()
        {
            return new List<EntityType>
            {
                new EntityType
                {
                    Id = 1,
                    Title = "Person",
                    Description = "This type is represented by the person entries like uber drivers."
                },
                new EntityType
                {
                    Id = 2,
                    Title = "Car",
                    Description = "This entity type is defined by car entries."
                },
                new EntityType
                {
                    Id = 3,
                    Title = "Book",
                    Description = "This entity type is defined by book entries."
                },
                new EntityType
                {
                    Id = 4,
                    Title = "Movie",
                    Description = "This entity type is defined by movie entries."
                },
                new EntityType
                {
                    Id = 5,
                    Title = "Companies",
                    Description = "This entity type is defined by company entries."
                }
            };
        }
        public static List<EntityReviewed> GetEntityReviewedsMockData()
        {
            return new List<EntityReviewed>()
            {
                new EntityReviewed
                {
                    Id = 1,
                    Details = "FirstName:Remus,LastName:Ene,JobTitle:Driving Instructor",
                    Image = null,
                    EntityTypeId = 1
                },
                new EntityReviewed
                {
                    Id = 2,
                    Details = "Manufacturer:Honda,Model:Civic,Year:2015,FuelType:Petrol,UserFor:Driving Lessons",
                    Image = null,
                    EntityTypeId = 2
                },
                new EntityReviewed
                {
                    Id = 3,
                    Details = "Title:Red Rising,Author:Pierce Brown,Gender:SF",
                    Image = null,
                    EntityTypeId = 3
                },
                new EntityReviewed
                {
                    Id = 4,
                    Details = "Title:The Nun,Gender:Horror,Platform:Netflix",
                    Image = null,
                    EntityTypeId = 4
                },
                new EntityReviewed
                {
                    Id = 5,
                    Details = "Name:Endava,NumberOfEmployees:10000,Domain:IT Outsourcing",
                    Image = null,
                    EntityTypeId = 5
                }
            };
        }
        public static List<Review> GetReviewsMockData()
        {
            return new List<Review>()
            {
                new Review
                {
                    Id = 1,
                    Score = 4.5,
                    Comment = "A very good instructor",
                    UserId = 1,
                    EntityReviewedId = 1
                },
                new Review
                {
                    Id = 2,
                    Score = 4.0,
                    Comment = "A very good car for begginer",
                    UserId = 2,
                    EntityReviewedId = 2
                },
                new Review
                {
                    Id = 3,
                    Score = 4.0,
                    Comment = "A very good book",
                    UserId = 3,
                    EntityReviewedId = 3
                },
                new Review
                {
                    Id = 4,
                    Score = 3.5,
                    Comment = "An acceptable movie",
                    UserId = 1,
                    EntityReviewedId = 4
                },
                new Review
                {
                    Id = 5,
                    Score = 0.5,
                    Comment = "A bad company",
                    UserId = 2,
                    EntityReviewedId = 5
                }
            };
        }
        public static List<ReviewAttachments> GetReviewAttachmentsMockData()
        {
            return new List<ReviewAttachments>()
            {
                new ReviewAttachments
                {
                    Id = 1,
                    Attachment = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    ReviewId = 2
                },
                new ReviewAttachments
                {
                    Id = 2,
                    Attachment = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    ReviewId = 3
                },
                new ReviewAttachments
                {
                    Id = 3,
                    Attachment = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    ReviewId = 4
                }
            };
        }
        public static List<Comment> GetCommentsMockData()
        {
            return new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Message = "A short message 1",
                    ReviewId = 1
                },
                new Comment
                {
                    Id = 2,
                    Message = "A short message 2",
                    ReviewId = 1
                },
                new Comment
                {
                    Id = 3,
                    Message = "A short message 3",
                    ReviewId = 2
                },
                new Comment
                {
                    Id = 4,
                    Message = "A short message 4",
                    ReviewId = 3
                }
            };
        }
        public static List<Suggestion> GetSuggestionMockData()
        {
            return new List<Suggestion>()
            {
                new Suggestion
                {
                    Id = 1,
                    Title = "New feature",
                    Description = "Adding a new feature",
                    Votes = 1,
                    UserId = 1
                },
                new Suggestion
                {
                    Id = 2,
                    Title = "New feature 2",
                    Description = "Adding a new feature 2",
                    Votes = 2,
                    UserId = 1
                },
                new Suggestion
                {
                    Id = 3,
                    Title = "New feature 3",
                    Description = "Adding a new feature 3",
                    Votes = 100,
                    UserId = 2
                }
            };
        }
    }
}
