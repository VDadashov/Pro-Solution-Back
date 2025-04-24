using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProSolution.Core.Entities;

namespace ProSolution.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Slider> Sliders { get; set; } 
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Catagory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CatagoryId)
                .OnDelete(DeleteBehavior.Cascade);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
