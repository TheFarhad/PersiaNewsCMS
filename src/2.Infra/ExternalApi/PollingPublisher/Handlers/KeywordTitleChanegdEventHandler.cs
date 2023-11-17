namespace PollingPublisher.Handlers;

using System.Threading.Tasks;
using Sky.App.Core.Contract.Services.Event;
using Events;

public class KeywordTitleChanegdEventHandler : IEventHandler<KeywordTitleChangedEvent>
{
    public async Task HandleAsync(KeywordTitleChangedEvent Source)
    {
        throw new NotImplementedException();
    }
}
