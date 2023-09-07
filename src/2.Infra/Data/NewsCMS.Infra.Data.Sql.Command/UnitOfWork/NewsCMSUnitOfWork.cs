namespace NewsCMS.Infra.Data.Sql.Command.Configurations;

using Sky.App.Infra.Data.Sql.Command;
using Contexts;
using Core.Contract.Infra.Command;

public class NewsCMSUnitOfWork : UnitOfWork<NewsCMSCommandDbContext>, INewsCMSUnitOfWork
{
    public NewsCMSUnitOfWork(NewsCMSCommandDbContext context) : base(context) { }
}
