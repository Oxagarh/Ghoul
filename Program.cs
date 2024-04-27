using Ghoul.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WastelandContext>(Options => Options.UseInMemoryDatabase("RobCo"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//  dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
//  dotnet add package Microsoft.EntityFrameworkCore.Design
//  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//  dotnet add package Microsoft.EntityFrameworkCore.Tools
//  dotnet tool install --global dotnet-aspnet-codegenerator
