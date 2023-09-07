namespace NewsCMS.Core.Contract.Services.Command;

using Sky.App.Core.Contract.Services.Command;

public class NewsEditCommand : ICommand<NewsEditPayload>
{
    public Guid Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<Guid> Keywords { get; set; }
}

public class NewsEditPayload
{
    public long Id { get; set; }
}
