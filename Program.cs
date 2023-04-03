using System.Reflection;
using ChuckSwapi.Api.Application.Commands.GenerateJokeCommand;
using ChuckSwapi.Api.Application.Queries.CategoriesQuery;
using ChuckSwapi.Api.Application.Queries.PeopleQuery;
using ChuckSwapi.Api.Application.Queries.SearchQuery;
using ChuckSwapi.Api.Application.Services;
using ChuckSwapi.Api.Application.Services.Interfaces;
using ChuckSwapi.Api.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ILoadMockData, LoadMockData>();
builder.Services.AddScoped<IChuckNorrisService, ChuckNorrisService>();
builder.Services.AddScoped<IStarWarsService, StarWarsService>();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddMediatR(typeof(GenerateJokeCommand));
builder.Services.AddMediatR(typeof(GenerateJokeCommandHandler));

builder.Services.AddMediatR(typeof(PeopleQuery));
builder.Services.AddMediatR(typeof(PeopleQueryHandler));

builder.Services.AddMediatR(typeof(SearchQueryHandler));
builder.Services.AddMediatR(typeof(SearchQuery));

builder.Services.AddMediatR(typeof(CategoriesQuery));
builder.Services.AddMediatR(typeof(CategoriesQueryHandler));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
