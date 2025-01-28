using Microsoft.EntityFrameworkCore;
using WatchListNetflix.Data;
using WatchListNetflix.Model.Entities;
using WatchListNetflix.Services.Audiovisuals;
using WatchListNetflix.Services.AutoMappers;
using WatchListNetflix.Services.Mappers;
using WatchListNetflix.Services.Watchlists;

var builder = WebApplication.CreateBuilder(args);

//Config DB
builder.Services.AddDbContext<WatchListNetflixContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSql")));

builder.Services.AddScoped<IAudiovisualService, AudiovisualService>();
builder.Services.AddScoped<IWatchlistService, WatchlistService>();

//Add AutoMappers
builder.Services.AddAutoMapper(typeof(WatchlistAutomappers));
builder.Services.AddAutoMapper(typeof(AudiovisualAutomapper));
builder.Services.AddAutoMapper(typeof(UserAutomappers));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
