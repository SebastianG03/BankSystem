using APIBankService.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBankService.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options
            ) : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<BankAccount> bankAccount { get; set; }
        public DbSet<Transferencia> transferencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount
                {
                    IdAccount = 1,
                    IdUser = 1,
                    AccountNumber = 1,
                    AccountAmount = 1,
                }

                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    Name = "Isaac",
                    Email = "isaac@gmail.com",
                    Password = "2234334",
                    Phone= "233334",
                    Role = "1",
                    DNI = "1",
                }

                );

        }

    }
}

