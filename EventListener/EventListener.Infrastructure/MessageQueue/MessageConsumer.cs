using EventListener.Application.Commands;
using EventListener.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;
using System.Text.Json;

namespace EventListener.Infrastructure.MessageQueue
{
    public class MessageConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public MessageConsumer(IServiceProvider serviceProvider)
        {
            InitializeRabbitMQ();
            _serviceProvider = serviceProvider;
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "user",
                Password = "mypass",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare("order", durable: true, exclusive: false);
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, eventArgs) =>
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var body = eventArgs.Body.ToArray();
                var jsonString = Encoding.UTF8.GetString(body);

                var order = JsonSerializer.Deserialize<Order>(jsonString);
                Log.Information("Order => {order}", order);
                await mediator.Send(new SaveOrderRequest(order));
            };

            _channel.BasicConsume("order", false, consumer);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
