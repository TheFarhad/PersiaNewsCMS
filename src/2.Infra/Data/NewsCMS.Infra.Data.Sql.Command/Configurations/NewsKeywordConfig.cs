namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sky.App.Infra.Data.Sql.Command.Configuration;
using Core.Domain.Aggregates.References;

public class NewsKeywordConfig : IEntityConfig<NewsKeyword>
{
    public void Configure(EntityTypeBuilder<NewsKeyword> builder)
    {
        builder
            .ToTable("NewsKeywords");

        builder
            .HasKey(_ => _.Id);
    }
}
