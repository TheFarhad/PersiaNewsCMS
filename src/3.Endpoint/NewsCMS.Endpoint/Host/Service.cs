namespace NewsCMS.Endpoint.Host;

using Steeltoe.Discovery.Client;
using Microsoft.EntityFrameworkCore;
using Sky.Kernel.Filing.Wireup;
using Sky.Kernel.Identity.Wireup;
using Sky.Kernel.Hashing.Wireup;
using Sky.App.Infra.Data.Sql.Query;
using Sky.Kernel.Serializing.Wireup;
using Sky.App.Endpoint.Api.Extentions;
using Sky.App.Infra.Data.Sql.Command;
using Sky.App.Infra.Data.Sql.Command.Interceptors;
using NewsCMS.Infra.Data.Sql.Command.Contexts;
using NewsCMS.Infra.Data.Sql.Query.Contexts;

internal static class Service
{
    internal static void Host(string[] args) => WebApplication.CreateBuilder(args).Services().Middlewares();
    private static WebApplication Services(this WebApplicationBuilder source)
    {
        var configuration = source.Configuration;

        var commandDbConn = configuration.GetConnectionString("NewsCMSCommandDbConn");
        var queryDbConn = configuration.GetConnectionString("NewsCMSQueryDbConn");

        source
        .Services
        .AddDiscoveryClient()
       .AddDbContext<NewsCMSCommandDbContext>(_ =>
       {
           _
           .UseSqlServer(commandDbConn)
           .AddInterceptors(new EventSourcingCommandDbContextInterceptor());
       })
       .AddDbContext<NewsCMSQueryDbContext>(_ =>
       {
           _.UseSqlServer(queryDbConn);
       })
       .FilerWireup()
       .UploaderWireup()
       .NewtonSoftSerializerWireup()
       .BCryptHashingWireup()
       .FakeUserServiceWireup()
       .WebApiWireup("Sky", "NewsCMS")
       .AddEndpointsApiExplorer()
       .AddSwaggerGen();

        return source.Build();
    }
    private static void Middlewares(this WebApplication source)
    {
        if (source.Environment.IsDevelopment())
        {
            source.UseSwagger();
            source.UseSwaggerUI();
        }
        source.UseHttpsRedirection();
        source.UseAuthorization();
        source.MapControllers();
        source.Run();
    }
}
