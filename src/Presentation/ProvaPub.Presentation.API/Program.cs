using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.Facades;
using ProvaPub.Application.Factories;
using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.SeedWork;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options => options.Filters.Add(typeof(ApiGlobalExceptionFilter))).AddJsonOptions(jsonOptions => { });
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GenerateRandomNumberHandler).Assembly));

//builder.Services.AddDbContext<ProvaPubContext>(options =>
//{
//    options.UseInMemoryDatabase("memory");
//});

builder.Services.AddDbContext<ProvaPubContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ctx"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRandomNumberRepository, RandomNumberRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IPaymentMethodFactory, PaymentMethodFactory>();
builder.Services.AddScoped<IPaymentFacade, PaymentFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prova BonifiQ"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
