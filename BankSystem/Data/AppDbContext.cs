using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public string DBPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dataFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Data"));

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            var dbPath = Path.Combine(dataFolder, "BankingSystem.db");
            options.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(t => t.BankAccount).WithMany(b => b.Transactions).HasForeignKey(t => t.AccountId);
            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount
                {
                    AccountId = 1,
                    OwnerName = "Danh Binh Tinh",
                    OwnerAddress = "11 ABC",
                    OwnerPhone = "0903112233",
                    Balance = 1000,
                    AccountType = "Checking",
                    Password = "123456",
                },
                new BankAccount
                {
                    AccountId = 2,
                    OwnerName = "Nguyen Hoang Minh",
                    OwnerAddress = "12 DEF",
                    OwnerPhone = "0903445566",
                    Balance = 2000,
                    AccountType = "Checking",
                    Password = "123456",
                },
                new BankAccount
                {
                    AccountId = 3,
                    OwnerName = "Nguyen Ngoc Thao Van",
                    OwnerAddress = "13 GHI",
                    OwnerPhone = "0903778899",
                    Balance = 3000,
                    AccountType = "Checking",
                    Password = "123456",
                }
            );
        }
    }
}
