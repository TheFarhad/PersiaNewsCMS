namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sky.App.Infra.Data.Sql.Command;
using Sky.App.Core.Contract.Infra.Command;
using Contexts;
using Core.Contract.Infra.Command;
using Core.Domain.Aggregates.Source;

public class NewsCommandRepository : CommandRepository<News, NewsCMSCommandDbContext>, INewsCommandRepository
{
    public NewsCommandRepository(NewsCMSCommandDbContext context) : base(context) { }

    public async Task<List<OutboxEvent>> Get(int maxCount = 100) =>
       await _context
        .OutboxEvents
        .Take(maxCount)
        .ToListAsync();

    public async Task MarkAsRead(List<OutboxEvent> outBoxEventItems)
    {
        // do somthing...
        await Task.CompletedTask;
    }
}
