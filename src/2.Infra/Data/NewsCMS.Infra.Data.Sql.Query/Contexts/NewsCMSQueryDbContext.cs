namespace NewsCMS.Infra.Data.Sql.Query.Contexts;

using Microsoft.EntityFrameworkCore;
using Sky.App.Infra.Data.Sql.Query;
using DbSets;

public class NewsCMSQueryDbContext : QueryDbContext
{
    public DbSet<News> News => Set<News>();
    public DbSet<Keyword> Keywords => Set<Keyword>();

    public NewsCMSQueryDbContext(DbContextOptions<NewsCMSQueryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
