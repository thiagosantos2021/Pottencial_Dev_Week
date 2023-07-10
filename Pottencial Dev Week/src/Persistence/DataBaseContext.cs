using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options){
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Person>(tabela => {
            tabela.HasKey(e => e.Id);
            tabela.HasMany(e => e.contracts).WithOne().HasForeignKey(c => c.TokenId);
        });

        builder.Entity<Contract>(tabela => {
            tabela.HasKey(e => e.Id);
        });
    }
}