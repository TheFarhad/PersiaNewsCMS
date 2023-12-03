namespace PollingPublisher.Subscribers;

using System;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sky.App.Core.Service.Event;
using Sky.Kernel.Serializing.Abstraction;
using Events;

public class KeywordConsumer : BackgroundService
{
    private long _messageCount;
    private readonly IModel _model;
    private readonly string _exchange = "PersiaNews";
    private readonly string _bindKey = "PersiaNews.BasicInfo.KeywordEventPulisher";
    private readonly ISerialize _serializer;
    private readonly EventDispatcher _eventDispatcher;

    public KeywordConsumer(ISerialize serializeing, IServiceProvider serviceProvider)
    {
        _serializer = serializeing;
        _eventDispatcher = serviceProvider.GetRequiredService<EventDispatcher>();

        var connection = new ConnectionFactory
        {
            HostName = "localhost",
        }.CreateConnection();
        _model = connection.CreateModel();
        _model.ExchangeDeclare(_exchange, ExchangeType.Topic);
        var queueName = _model.QueueDeclare().QueueName;
        _model.QueueBind(queueName, _exchange, _bindKey);
        var consumer = new EventingBasicConsumer(_model);
        _model.BasicConsume(queueName, true, consumer);
        consumer.Received += ReceiveEvent;
    }

    private async void ReceiveEvent(object? sender, BasicDeliverEventArgs args)
    {
        var jsonBody = Encoding.UTF8.GetString(args.Body.ToArray());
        var keywordCreatedEvent = _serializer.Deserialize<KeywordCreatedEvent>(jsonBody);
        await _eventDispatcher.DispatchAsync<KeywordCreatedEvent>(keywordCreatedEvent);
        _messageCount++;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"The number of received events is equal to: {_messageCount}");
            await Task.Delay(10000, stoppingToken);
        }
    }
}

