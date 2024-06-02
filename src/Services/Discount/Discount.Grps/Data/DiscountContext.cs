using Discount.Grps.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Discount.Grps.Data
{
    public class DiscountContext :DbContext
    {
        public DbSet<Coupon> Coupon { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> dbContextOptions) :base(dbContextOptions) {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Discount", Amount = 150 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 }
                );
        }
    }
}
