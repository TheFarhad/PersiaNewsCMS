namespace NewsCMS.Endpoint.Extentions;

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

internal static class Service
{
    internal static void Host(string[] args) => WebApplication.CreateBuilder(args).Services().Middlewares();
    private static WebApplication Services(this WebApplicationBuilder source)
    {
        var configuration = source.Configuration;

        var commandDbConn = configuration.GetConnectionString("CommandDbConn");
        var queryDbConn = configuration.GetConnectionString("QueryDbConn");

        source
        .Services
        .AddDiscoveryClient()
       .AddDbContext<CommandDbContext>(_ =>
       {
           _
           .UseSqlServer(commandDbConn)
           .AddInterceptors(new CommandDbContextInterceptor());
       })
       .AddDbContext<QueryDbContext>(_ =>
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
