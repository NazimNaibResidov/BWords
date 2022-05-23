using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BWords.Common.Infrastructure
{
   
    public static class QueueFactory
    {
        public static void SendMessageToExchange(string exchangeName,string exchangeType,string queueName,object obj)
        {
            var channel = CreateBasicConsumer()
                   .EnsureExchange(exchangeName, exchangeType)
                   .EnsureQueue(queueName, exchangeName)
                   .Model;
            var _body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
             channel.BasicPublish(exchangeName,queueName,null, _body);

        }
        public static EventingBasicConsumer CreateBasicConsumer()
        {
            var factory = new ConnectionFactory() { HostName = WordConstants.RabbitMQHost };
            var connect = factory.CreateConnection();
            var channle = connect.CreateModel();
            return new EventingBasicConsumer(channle);
        }
        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consurmer, string exchangeName, string excaneType = WordConstants.defaultExcanceType)
        {
            consurmer.Model.ExchangeDeclare(exchangeName, excaneType, durable: false, autoDelete: false);
            return consurmer;
        }
        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consurmer, string QueueName, string excaneName )
        {
            consurmer.Model.QueueDeclare(QueueName, false, false,  false,null);
            consurmer.Model.QueueBind(QueueName, excaneName, QueueName);
            return consurmer;
        }
        
    }
   
}
