using Microsoft.EntityFrameworkCore;
using ReviewHub.Contexts;
using ReviewHub.Helpers;
using ReviewHub.Profiles;
using ReviewHub.Repositories.CommentRepository;
using ReviewHub.Repositories.EntityReviewedRepository;
using ReviewHub.Repositories.EntityTypeRepository;
using ReviewHub.Repositories.RankRepository;
using ReviewHub.Repositories.ReviewAttachementsRepository;
using ReviewHub.Repositories.ReviewRepository;
using ReviewHub.Repositories.RoleRepository;
using ReviewHub.Repositories.SuggestionRepository;
using ReviewHub.Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


#region ConnectionString configuration

builder.Services.AddDbContext<ReviewHubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReviewHubConnectionStringDEV")));

#endregion

#region ReviewHub services lifecycles

builder.Services.AddScoped<IUserRepository,  UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRankRepository, RankRepository>();
builder.Services.AddScoped<IEntityTypeRepository, EntityTypeRepository>();
builder.Services.AddScoped<IEntityReviewedRepository, EntityReviewedRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewAttachementsRepository, ReviewAttachementsRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();

#endregion

#region CORS Origins



#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePathBase(new PathString("/review-hub-api/[controller]"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
