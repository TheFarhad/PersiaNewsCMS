namespace NewsCMS.Core.Contract.Infra.Command;

using Sky.App.Core.Contract.Infra.Command;
using Domain.Aggregates.Source;

public interface INewsCommandRepository : ICommandRepository<News>, IEventSorcingRepository { }
