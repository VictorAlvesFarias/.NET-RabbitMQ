using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Domain.Interfaces;
using RabbitMQ.Client.Events;
using Domain.Entities;

namespace Oebm_Producer.Context { 
    public abstract class AMQPAbstractContext : IAMQPAbstractContext
    {
        public readonly IConnection Connection;
        public readonly IModel Channel;
        public AMQPAbstractContext()
        {
            var type = this.GetType();
            var context = AMQPContext.AMQPContextModelList.FirstOrDefault(e => e.Instance == type);
            
            Connection = context.Connection;
            Channel = context.Channel;
        }
        public void Sender(object body, string exchange)
        {
            var item = WriteItem(body, exchange);

            var bodyBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));

            Channel.BasicPublish(
                exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: bodyBytes
            );

            Channel.BasicAcks += (sender, ea) =>
            {
                DeleteItem(item.Result.Id);
            };
        }
        public virtual async Task<AMQPDeathQueueItem> WriteItem(object body, string exchange)
        {
            return null;
        }
        public virtual async void DeleteItem(int id)
        {

        }
    }
}