namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sky.App.Infra.Data.Sql.Command.Configuration;
using Core.Domain.Aggregates.References;

public class KeywordConfig : IEntityConfig<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder
            .ToTable("Keywords");

        builder
            .HasKey(_ => _.Id);
    }
}
