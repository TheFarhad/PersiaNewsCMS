namespace NewsCMS.Core.Domain.Aggregates.Elements;

using Sky.App.Core.Domain.Shared.ValueObjects;

public class NewsTitle : EString
{
    private NewsTitle() { }
    private NewsTitle(string value) : base(value, 3, 200) { }

    public static NewsTitle Instance(string value) => new(value);

    public static explicit operator string(NewsTitle source) => source.Value;
    public static implicit operator NewsTitle(string value) => Instance(value);
}
