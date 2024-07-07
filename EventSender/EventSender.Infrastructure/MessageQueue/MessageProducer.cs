using EventSender.Application.Contract.IInfrastructure;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventSender.Infrastructure.MessageQueue
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory 
            { 
                HostName = "localhost",
                UserName = "user", 
                Password = "mypass", 
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("order", durable: true, exclusive: false);

            var jsonString = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "order", body: body);
        }
    }
}
