using Domain.ContextModels;
using Microsoft.AspNetCore.Identity;
using Oebm_Producer.Context;
using Oebm_Producer.Factorys;
using Oebm_Producer.Mediators;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text;

namespace Oebm_Producer.Extensions
{
    public static class AMQPSetup
    {
        public static void AddRabbitMQContext<T>(this IServiceCollection services, Expression<Func<AddRabbitMQContextCallbackWrapper<T>, AMQPContextModel>> func)
        {
            var context = func.Compile()(new AddRabbitMQContextCallbackWrapper<T>());

            AMQPContext.AMQPContextModelList.Add(context);
        }
        public static void AddRabbitMQCustumers(this IServiceCollection services)
        {
            AMQPContext.SetConsumers<AppAMQPContext>(e =>
            {
                e.Consumer("", (sender, args) =>
                {
                    Console.WriteLine(Encoding.UTF8.GetString(args.Body.ToArray()));
                    e.Channel.BasicAck(args.DeliveryTag, multiple: false);
                });
            });
        }
    }
}
