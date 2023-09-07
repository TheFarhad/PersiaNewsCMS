namespace NewsCMS.Core.Application.Event;

using Sky.App.Core.Contract.Services.Event;
using Domain.Aggregates.Events;

public class NewsCreatedEventHandler : IEventHandler<NewsCreatedEvent>
{
    public Task HandleAsync(NewsCreatedEvent Source)
    {

        return Task.CompletedTask;
    }
}