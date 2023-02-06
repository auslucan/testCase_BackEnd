using Microsoft.EntityFrameworkCore;
using CoursesAPI.Models;
using CoursesAPI.Data.Interfaces;
using CoursesAPI.Data.Repositories;
using CoursesAPI.Interfaces;
using CoursesAPI.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<ICourseDetailRepository, CourseDetailRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<ICourseManager, CourseManager>();
builder.Services.AddTransient<ICourseDetailManager, CourseDetailManager>();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<CourseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CourseConnection")));



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var movieContext = scope.ServiceProvider.GetRequiredService<CourseContext>();
        movieContext.Database.EnsureCreated();

    }
}

app.UseCors("corsapp");
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
