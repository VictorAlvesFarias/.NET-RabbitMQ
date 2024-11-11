using Oebm_Producer.Context;
using Oebm_Producer.Extensions;

namespace Oebm_Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddRabbitMQContext<AppAMQPContext>(e=>
                e.CreateChanel("", "", "")
            );

            builder.Services.AddRabbitMQCustumers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
