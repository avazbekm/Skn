using Microsoft.EntityFrameworkCore;
using Skn.Domain.Entities;

namespace Skn.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<SimCard> SimCards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Entitylar uchun "IsDeleted" holatini filter qilish
        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<SimCard>().HasQueryFilter(u => !u.IsDeleted);
        #endregion
    }
}
