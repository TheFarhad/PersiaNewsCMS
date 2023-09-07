namespace NewsCMS.Core.Domain.Aggregates.Source;

using Sky.App.Core.Domain.Aggregate.Entity;
using Sky.App.Core.Domain.Shared.ValueObjects;
using Events;
using Elements;
using References;

public class News : Source
{
    public NewsTitle Title { get; private set; }
    public Description Description { get; private set; }
    public string Body { get; private set; }
    private List<Keyword> _keywords = new();
    public IReadOnlyList<Keyword> Keywords => _keywords.AsReadOnly();

    private News() { }
    private News(NewsTitle title, Description description, string body, List<Keyword> keywords) =>
        Init(title, description, body, keywords, null);

    public static News Instance(NewsTitle title, Description description, string body, List<Keyword> keywords) => new(title, description, body, keywords);

    private void Init(NewsTitle title, Description description, string body, List<Keyword> keywords, Action action = null)
    {
        Apply(NewsCreatedEvent.Instance(Code.Value, title.Value, description.Value, body, keywords));
        SetKeywords(keywords);
        action?.Invoke();
    }

    public void Edit(NewsTitle title, Description description, string body, List<Keyword> keywords)
    {
        Apply(NewsEditedEvent.Instance(Code.Value, title.Value, description.Value, body, keywords));
        SetKeywords(keywords);
    }

    private void On(NewsCreatedEvent source) =>
         SetPropeties(source.Title, source.Description, source.Body);

    private void On(NewsEditedEvent source) =>
          SetPropeties(source.Title, source.Description, source.Body);

    private void SetKeywords(List<Keyword> keywords) => _keywords = keywords;

    private void SetPropeties(string title, string description, string body)
    {
        Title = title;
        Description = description;
        Body = body;
    }
}
