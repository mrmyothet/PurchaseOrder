using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Models;

namespace PurchaseOrder.API;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<VendorContextModel> Vendor { get; set; }
}
