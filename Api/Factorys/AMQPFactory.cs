
using Domain.ContextModels;
using RabbitMQ.Client;

namespace Oebm_Producer.Factorys
{
    public class AMQPFactory
    {
        public AMQPContextModel CreateChanel(string hostname, string username, string password,Type type)
        {
            var factory = new ConnectionFactory()
            {
                HostName = hostname,
                UserName = username,
                Password = password,
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var response = new AMQPContextModel(channel, connection, type);

            return response;
        }
    }
}
