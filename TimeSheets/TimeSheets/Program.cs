using Microsoft.EntityFrameworkCore;
using TimeSheets;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL;
using TimeSheets.DAL.Validation;

var builder = WebApplication.CreateBuilder(args);

//CreateHostBuilder(args).Build().Run();

//public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = Config.GetConnectionString("myDb");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(connectionString));

//builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<PersonVallidationService>();

var app = builder.Build();
//using var app = builder.Build();

startup.Configure(app, app.Environment);

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
