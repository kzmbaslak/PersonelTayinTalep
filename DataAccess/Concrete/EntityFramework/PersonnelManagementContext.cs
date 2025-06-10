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
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PersonnelManagement;Trusted_Connection=true");
            optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=PersonnelManagement;Username=postgres;Password=toor");
            //postgres
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
            base.OnModelCreating(modelBuilder);

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

            initDataValues(modelBuilder);
        }

        private void initDataValues(ModelBuilder modelBuilder)
        {
            // 81 şehir verisi
            var cityNames = new[]
            {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara",
            "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis",
            "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
            "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Isparta",
            "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli",
            "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş",
            "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
            "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon",
            "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray",
            "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
            "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
        };

            // City kayıtlarını hazırla
            var cities = cityNames.Select((name, index) => new City
            {
                Id = index + 1,
                Name = name
            }).ToList();

            modelBuilder.Entity<City>().HasData(cities);

            // Courthouse kayıtları (şehir adına göre)
            var courthouses = cities.Select(c => new Courthouse
            {
                Id = c.Id,
                Name = $"{c.Name} Adliyesi",
                CityId = c.Id
            }).ToList();

            modelBuilder.Entity<Courthouse>().HasData(courthouses);

            // TransferType kayıtları
            modelBuilder.Entity<TransferType>().HasData(
                new TransferType { Id = 1, Name = "Eş Durum" },
                new TransferType { Id = 2, Name = "Tayin" },
                new TransferType { Id = 3, Name = "Mazeret" }
            );
        }
    }
}
