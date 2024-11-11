using Domain.ContextModels;
using Oebm_Producer.Factorys;

namespace Oebm_Producer.Mediators
{
    public class AddRabbitMQContextCallbackMediator<T>
    {
        public AMQPContextModel CreateChanel(string hostname, string username, string password)
        {
            var typeOfT = typeof(T);
            var factory = new AMQPFactory();
            var response = factory.CreateChanel(hostname, username, password, typeOfT);

            return response;
        }
    }
}
