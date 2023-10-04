using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class DibaContext:DbContext
    {
        public DibaContext(DbContextOptions<DibaContext> option):base(option)
        {
            
        }
      

        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<Color> ColorProducts { get; set; }
        public DbSet<Size> SizeProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public  DbSet<ExclusiveOffer> ExclusiveOffers{ get; set; }
        public  DbSet<Order> Orders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<UserComment> UserComments { get; set; }


    }
}
