using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndreTurismoDapperProjAddressService.Data;
using AndreTurismoDapperProjAddressService.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AndreTurismoDapperProjAddressServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AndreTurismoDapperProjAddressServiceContext") ?? throw new InvalidOperationException("Connection string 'AndreTurismoDapperProjAddressServiceContext' not found.")));

// Add services to the container.
builder.Services.AddSingleton<PostOfficeService>();

builder.Services.AddControllers();
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
