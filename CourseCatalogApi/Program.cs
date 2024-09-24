using CourseCatalogApi;
using CourseCatalogDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add course catalog services to DI container.
builder.Services
    .AddDbContext<CourseCatalogDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"))
    .Configure<CatalogOptions>(builder.Configuration.GetSection(CatalogOptions.Name));

// "Build" configured app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (builder.Configuration.GetValue("UseHttps", true)) 
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
