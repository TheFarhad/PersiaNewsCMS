namespace NewsCMS.Core.Contract.Services.Command;

using Sky.App.Core.Contract.Services.Command;

public class NewsCreateCommand : ICommand<NewsCreatePayload>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<Guid> Keywords { get; set; }
}

public class NewsCreatePayload
{
    public long Id { get; set; }
}

