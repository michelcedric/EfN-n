using EfN_n.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfN_n.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ActiveDirectoryObject> ActiveDirectoryObject { get; set; }

        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<RoleFeature>().HasKey(x => new {x.FeatureId, x.RoleId});

            modelBuilder.Entity<RoleFeature>()
                .HasOne(pt => pt.Role)
                .WithMany(p => p.RoleFeatures)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<RoleFeature>()
                .HasOne(pt => pt.Feature)
                .WithMany(t => t.RoleFeatures)
                .HasForeignKey(pt => pt.FeatureId);          
        }

    }
}
