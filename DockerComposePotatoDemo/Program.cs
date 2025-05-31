
using DockerComposePotatoDemo.Data;
using DockerComposePotatoDemo.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Name = "Coca-Cola", Price = 10 },
            new Product { Name = "Fanta", Price = 15 },
            new Product { Name = "7Up", Price = 12 }
        );
        context.SaveChanges();
    }
}

app.MapGet("/products", async (ApplicationDbContext context) =>
{
    return await context.Products.ToListAsync();
});

app.MapPost("/products", async (Product product, ApplicationDbContext context) =>
{
    context.Products.Add(product);
    await context.SaveChangesAsync();
    return Results.Created($"/products/{product.Id}", product);
});

app.MapControllers();

app.Run();

