using Microsoft.EntityFrameworkCore;
using PurchaseTracker.Api.Models;

namespace PurchaseTracker.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    DbSet<PurchaseItem> Purchases { get; set; }
}