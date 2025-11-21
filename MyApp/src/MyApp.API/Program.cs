using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Read connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register MySQL DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
