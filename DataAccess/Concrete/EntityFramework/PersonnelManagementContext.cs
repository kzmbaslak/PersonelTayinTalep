using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class PersonnelManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonnelManagement;Trusted_Connection=true");
        }

        public DbSet<Courthouse> Courthouses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<TransferRequest> TransferRequests { get; set; }

        public DbSet<TransferType> TransferTypes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courthouse>()
                .HasOne(ch => ch.City)
                .WithMany(c => c.Courthouses)
                .HasForeignKey(ch => ch.CityId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete istemiyor

            // Diğer konfigürasyonlar (opsiyonel)
            modelBuilder.Entity<Courthouse>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
