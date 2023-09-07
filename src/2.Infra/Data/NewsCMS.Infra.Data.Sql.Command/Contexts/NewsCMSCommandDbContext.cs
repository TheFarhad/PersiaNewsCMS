namespace NewsCMS.Infra.Data.Sql.Command.Contexts;

using Microsoft.EntityFrameworkCore;
using Sky.App.Infra.Data.Sql.Command;
using Core.Domain.Aggregates.Source;

public class NewsCMSCommandDbContext : EventSourcingCommandDbContext
{
    public DbSet<News> News => Set<News>();

    private NewsCMSCommandDbContext() { }
    public NewsCMSCommandDbContext(DbContextOptions<NewsCMSCommandDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
}
