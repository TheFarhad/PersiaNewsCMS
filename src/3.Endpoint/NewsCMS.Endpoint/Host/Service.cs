namespace NewsCMS.Endpoint.Host;

using Steeltoe.Discovery.Client;
using Microsoft.EntityFrameworkCore;
using Sky.Kernel.Filing.Wireup;
using Sky.Kernel.Identity.Wireup;
using Sky.Kernel.Hashing.Wireup;
using Sky.Kernel.Serializing.Wireup;
using Sky.App.Endpoint.Api.Extentions;
using Sky.App.Infra.Data.Sql.Command.Interceptors;
using PollingPublisher.Subscribers;
using Infra.Data.Sql.Query.Contexts;
using Infra.Data.Sql.Command.Contexts;

internal static class Service
{
    internal static void Host(string[] args) => WebApplication.CreateBuilder(args).Services().Pipeline();
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
       .AddHostedService<KeywordConsumer>()
       .AddSwaggerGen();

        return source.Build();
    }
    private static void Pipeline(this WebApplication source)
    {
        if (source.Environment.IsDevelopment())
        {
            source.UseSwagger();
            source.UseSwaggerUI();
        }
        //source.UseHttpsRedirection();
        source.UseAuthorization();
        source.MapControllers();
        source.Run();
    }
}
