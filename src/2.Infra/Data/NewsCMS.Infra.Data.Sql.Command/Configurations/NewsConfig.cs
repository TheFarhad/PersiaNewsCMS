namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sky.App.Infra.Data.Sql.Command.Configuration;
using Core.Domain.Aggregates.Source;

public class NewsConfig : IEntityConfig<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder
            .ToTable("News");

        builder
            .HasKey(_ => _.Id);

        builder
            .Property(_ => _.Title)
            .HasMaxLength(200)
            .HasConversion<NewsTitleConverter>()
            .IsRequired();

        builder
            .Property(_ => _.Description)
            .HasMaxLength(500);

        builder
            .Property(_ => _.Body)
            .IsRequired();
    }
}