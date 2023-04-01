using _02_ReportProject.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_ReportProject.Context;

internal class DataContext : DbContext
{
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abdul\Desktop\02_ReportApp\02_ReportProject\Context\EntityFrameworkBase.mdf;Integrated Security=True;Connect Timeout=30");
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Case> Cases { get; set; }
}
