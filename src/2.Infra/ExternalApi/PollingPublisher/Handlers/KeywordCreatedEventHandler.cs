namespace PollingPublisher.Handlers;

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Sky.App.Core.Contract.Services.Event;
using Events;

public class KeywordCreatedEventHandler : IEventHandler<KeywordCreatedEvent>
{
    public async Task HandleAsync(KeywordCreatedEvent Source)
    {
        var sqlCn = new SqlConnection("Server=.\\DEVELOP; Database=NewsCMSDb; User Id=sa; Password=masih; Persist Security Info=true; Trust Server Certificate=true; Encrypt=false;");

        sqlCn.Open();

        var command = $"INSERT INTO [NewsCMSDb].[dbo].[Keywords] ([Code], [Title]) VALUES ('{Source.Code}', N'{Source.Title}');";
        var sqlCommand = new SqlCommand(command, sqlCn);
        sqlCommand.ExecuteNonQuery();

        sqlCn.Close();
    }
}