using MyFeedback.Infrastructure;
using MyFeedback.Application;
using MyFeedback.Application.Query;
using MyFeedback.Infrastructure.Query;
using MyFeedback.Backend.Controllers;
using MyFeedback.Backend;
using System.Net;

var builder = WebApplication.CreateBuilder(args);



// Add controllers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tilføjer vores to separate Dependency Injection-klasser fra Application-, Infrastructure-lagene
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();