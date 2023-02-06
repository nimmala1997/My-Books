using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_books1.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var Logger = new LoggerConfiguration()
//.WriteTo.File("Logs/logs.txt",rollingInterval:RollingInterval.Day)
//.CreateLogger();

var Configuration = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .Build();

var Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(Configuration)
             .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Logger);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<PublishersService>();
builder.Services.AddScoped<AuthorsServices>();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


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

