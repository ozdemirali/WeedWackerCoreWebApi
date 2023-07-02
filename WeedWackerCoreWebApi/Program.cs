using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add connectionString 
builder.Services.AddDbContext<WeedWackerDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("WeedWackerConnection")));


//Add Repository
builder.Services.AddTransient<IWorkRepository,WorkRepository>();
builder.Services.AddTransient<IAddressRepository,AddressRepository>();
builder.Services.AddTransient<ISettingRepository, SettingRepository>();
builder.Services.AddTransient<ICustomerOfferRepository,CustomerOfferRepository>();
builder.Services.AddTransient<IEmployerOfferRepository, EmployerOfferRepository>();

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
