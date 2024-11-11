using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Domain.ContextModels;
using RabbitMQ.Client.Events;
using System.Threading.Channels;
using System.Linq.Expressions;

namespace Oebm_Producer.Context { 
    public static class AMQPContext
    {
        public static List<AMQPContextModel> AMQPContextModelList = new List<AMQPContextModel>();
        public static void SetConsumers<T>(Action<AMQPContextModel> func)
        {
            var context = AMQPContextModelList.FirstOrDefault(e => e.Instance == typeof(T));

            if (context == null)
            {
                throw new InvalidOperationException($"Contexto do tipo '{typeof(T).Name}' não foi encontrado.");
            }

            func(context);
        }
    }
}
