using BacendBuldinghamid.Database;
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
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Complaint> Complaints { get; set; }




        public DbSet<Subscribe> Subscribes { get; set; }

        

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
                entity.HasKey(b=>b.Id);
                entity.HasOne(b=>b.Manage).WithOne(b=>b.Building).HasForeignKey<Building>(b=>b.AccountMobile);
            });

            modelBuilder.Entity<Resident>(entity=>
            {
                entity.HasKey(m=>m.AccountMobile);
                entity.HasOne(m=>m.Account).WithOne(m=>m.Resident).HasForeignKey<Resident>(m=>m.AccountMobile);
                entity.HasOne(m=>m.Building).WithMany(m=>m.Resident).HasForeignKey(m=>m.BuildingId);
            });
            modelBuilder.Entity<Complaint>(entity=>
            {
                entity.HasKey(m=>m.Id);
                entity.HasOne(m=>m.Resident).WithMany(m=>m.complaints);
            });
            
     }

    }
}