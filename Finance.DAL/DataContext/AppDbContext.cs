using Finance.DAL.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ii => ii.Invoice)
                .WithMany(i => i.Items)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(ii => ii.UnitPrice)
                .HasPrecision(18, 2);


            var seedDate = new DateTime(2025, 01, 01);

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Əli Məmmədov",
                    Email = "ali@abc.az",
                    Phone = "+994501234567",
                    Company = "ABC Technologies MMC"
                },
                new Client
                {
                    Id = 2,
                    Name = "Leyla Əhmədova",
                    Email = "leyla@xyz.az",
                    Phone = "+994559876543",
                    Company = "XYZ Consulting"
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    Description = "Məhsul satışı - ABC MMC",
                    Amount = 5200m,
                    Type = TransactionType.Income,
                    Date = seedDate.AddDays(-1),
                    Category = "Satış"
                },
                new Transaction
                {
                    Id = 2,
                    Description = "Ofis icarəsi",
                    Amount = 1500m,
                    Type = TransactionType.Expense,
                    Date = seedDate.AddDays(-2),
                    Category = "İcarə"
                },
                new Transaction
                {
                    Id = 3,
                    Description = "Xidmət haqqı - XYZ MMC",
                    Amount = 3450m,
                    Type = TransactionType.Income,
                    Date = seedDate.AddDays(-3),
                    Category = "Xidmət"
                },
                new Transaction
                {
                    Id = 4,
                    Description = "İşçi maaşları",
                    Amount = 8500m,
                    Type = TransactionType.Expense,
                    Date = seedDate.AddDays(-4),
                    Category = "Əmək haqqı"
                },
                new Transaction
                {
                    Id = 5,
                    Description = "Məsləhət xidməti",
                    Amount = 2800m,
                    Type = TransactionType.Income,
                    Date = seedDate.AddDays(-5),
                    Category = "Konsaltinq"
                }
            );
        }
    }
}
