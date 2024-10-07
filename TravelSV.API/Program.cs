using Microsoft.EntityFrameworkCore;
using TravelSV.API.Configurations;
using TravelSV.API.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    "Server=tcp:travelsv-api-server.database.windows.net,1433;Initial Catalog=travelsv-api-database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\"";

// Configurar el servicio DbContext con SQL Server y la cadena de conexión
builder.Services.AddDbContext<TravelSvDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddSqliteConfiguration();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS if needed
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
