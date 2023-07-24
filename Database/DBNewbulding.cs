using Microsoft.EntityFrameworkCore;

namespace BacendBulding.Database
{
    public class DBNewbulding : DbContext
    {
        public DBNewbulding(DbContextOptions<DBNewbulding>options)
        :base(options)
        {
            
        }



        public DbSet<Account> Accounts { get; set; }
        public DbSet<Manage> Manages { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingCost> BuildingCosts { get; set; }

        

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity=>
            {
                entity.HasKey(m=>m.Mobile);
                entity.Property(m=>m.Mobile).HasMaxLength(10);
                entity.Property(m=>m.Mobile).IsRequired();
            });

            modelBuilder.Entity<Manage>(entity=>
            {
                entity.HasKey(m=>m.AccountMobile);
                entity.HasOne(m=>m.Account).WithOne(m=>m.Manage).HasForeignKey<Manage>(m=>m.AccountMobile);
            });

            modelBuilder.Entity<Building>(entity=>
            {
                entity.HasKey(b=>b.AccountMobile);
                entity.HasOne(b=>b.Manage).WithOne(b=>b.Building).HasForeignKey<Building>(b=>b.AccountMobile);
            });
            
     }

    }
}