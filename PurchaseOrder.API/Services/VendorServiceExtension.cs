namespace PurchaseOrder.API.Services;

public static class VendorServiceExtension
{
    public static void AddVendorService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<VendorService>();
    }
}
