using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API de Dashboard de Vendas - Mock");

app.MapGet("/api/dashboard/sales-summary", () => new
{
    TotalOrders = 1280,
    Revenue = 256000.50,
    Customers = 340,
    Products = 75
});

app.MapGet("/api/dashboard/sales-by-month", () =>
{
    var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul" };
    var random = new Random();
    var data = months.Select(m => new
    {
        Month = m,
        Total = random.Next(15000, 40000)
    });

    return data;
});

app.MapGet("/api/dashboard/top-products", () =>
{
    return new[]
    {
        new { Product = "Mouse", Sales = 320 },
        new { Product = "Keyboard", Sales = 280 },
        new { Product = "Monitor", Sales = 150 },
        new { Product = "Notebook", Sales = 100 },
        new { Product = "Headset", Sales = 85 }
    };
});

app.MapGet("/api/dashboard/sales-distribution", () =>
{
    return new[]
    {
        new { Channel = "Direct", Value = 40 },
        new { Channel = "Social", Value = 25 },
        new { Channel = "Marketing", Value = 20 },
        new { Channel = "Affiliates", Value = 15 }
    };
});

app.Run();