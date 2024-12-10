namespace PurchaseOrder.API.Services;

public static class ServiceExtensions
{
    public static void AddVendorService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<VendorService>();
    }

    public static void AddStockService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<StockService>();
    }
}
