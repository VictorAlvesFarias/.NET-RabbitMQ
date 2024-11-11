using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using System;

namespace Domain.ContextModels
{
    public class AMQPContextModel
    {
        public readonly IConnection Connection;
        public readonly IModel Channel;
        public readonly Type Instance;
        public AMQPContextModel(IModel channel, IConnection connection, Type instance)
        {
            Connection = connection;
            Channel = channel;
            Instance = instance;
        }
        public void Consumer(string queueName, EventHandler<BasicDeliverEventArgs> func)
        {
            var consumer = new EventingBasicConsumer(Channel);

            Channel.BasicConsume(
                queue: queueName,
                autoAck: false, 
                consumer: consumer
            );

            Task.Factory.StartNew(() =>
            {
                lock (Channel)
                {
                    consumer.Received += func;
                }
            });
        }
    }
}