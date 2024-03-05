using Microsoft.EntityFrameworkCore;
using WebApplication1.control.controls;
using WebApplication1.control.Icontrol;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ImemberControl, memberControl>();
builder.Services.AddScoped<ImemberTypeControl, memberTypeControl>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStrings = builder.Configuration.GetConnectionString("DataMember");
builder.Services.AddDbContext<DemoDbContext>(option =>
{
    option.UseSqlServer(connectionStrings);
});


builder.Services.AddScoped<ImemberControl, memberControl>();
builder.Services.AddScoped<ImemberTypeControl, memberTypeControl>();


//IConfiguration configuration;

//configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//builder.Services.AddDbContext<DemoDbContext>

//    (option => option.UseSqlServer(configuration.GetConnectionString("DataMember")));

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
