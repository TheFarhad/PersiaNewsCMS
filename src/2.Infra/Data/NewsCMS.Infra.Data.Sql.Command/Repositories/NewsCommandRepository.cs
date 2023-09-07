namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Microsoft.EntityFrameworkCore;
using NewsCMS.Core.Contract.Infra.Command;
using NewsCMS.Core.Domain.Aggregates.Source;
using NewsCMS.Infra.Data.Sql.Command.Contexts;
using Sky.App.Core.Contract.Infra.Command;
using Sky.App.Infra.Data.Sql.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
