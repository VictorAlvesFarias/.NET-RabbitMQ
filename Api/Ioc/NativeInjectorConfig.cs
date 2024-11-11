using Oebm_Producer.Context;

namespace App.Ioc
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<AppAMQPContext>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowedCorsOrigins",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
