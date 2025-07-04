using Microsoft.EntityFrameworkCore;
using OrderManagment.DataAccess.Context;
using OrderManagment.BusinessLogic.Profiles;
using OrderManagment.DataAccess.Interfaces;
using OrderManagment.DataAccess.Repositories;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.BusinessLogic.Service;
using OrderManagment.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check if the connection string is a URL from Render
if (Uri.TryCreate(connectionString, UriKind.Absolute, out var uri) && uri.Scheme.StartsWith("postgres"))
{
    var userInfo = uri.UserInfo.Split(':');
    var user = userInfo[0];
    var password = userInfo[1];
    var host = uri.Host;
    var port = uri.Port == -1 ? 5432 : uri.Port;
    var database = uri.LocalPath.TrimStart('/');
    
    // Convert the URL to the standard format
    connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};";
}

builder.Services.AddDbContext<OrderManagmentDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<OrderManagmentDbContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Since this is a educational project, swagger will remain enabled in production env
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();