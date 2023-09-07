namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Core.Domain.Aggregates.Elements;

public class NewsTitleConverter : ValueConverter<NewsTitle, string>
{
    public NewsTitleConverter() :
        base(_ => _.Value, _ => NewsTitle.Instance(_))
    { }
}
