using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Phones.Entities;

namespace PhoneBook.Infrastructures.Data.SqlServer
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
