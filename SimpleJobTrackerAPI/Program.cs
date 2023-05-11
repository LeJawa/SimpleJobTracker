using Microsoft.EntityFrameworkCore;
using SimpleJobTrackerAPI.Data;
using SimpleJobTrackerAPI.Services.OffersDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOffersDbService, OffersDbService>();
builder.Services.AddDbContext<OffersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DockerDbConnection")));

builder.Services.AddAutoMapper(typeof(JobOffersProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    
}

using (var scope = app.Services.CreateScope())
{
    var salesContext = scope.ServiceProvider.GetRequiredService<OffersDbContext>();
    salesContext.Database.EnsureCreated();
    salesContext.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
