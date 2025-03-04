using RetailStore.ApplicationLayer.Services.Implementations;
using RetailStore.DomainLayer.Repositories.Implementations;
using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Mappings;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Retail Store",
        Version = "v1",
        Description = "Basic Retail Store Management API",
    });
});

// SeriLog Configuration
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

// Db Context
builder.Services.AddDbContext<RetailStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

// Scoped Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<IDeliveryStatusRepository, DeliveryStatusRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IDeliveryDetailRepository, DeliveryDetailRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

// Scoped Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IDeliveryStatusService, DeliveryStatusService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IDeliveryDetailService, DeliveryDetailService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(ApplicationMappings).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Retail Store"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
