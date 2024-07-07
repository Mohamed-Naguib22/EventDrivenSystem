using EventSender.Application.Contract.IInfrastructure;
using EventSender.Infrastructure.MessageQueue;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMessageProducer), typeof(MessageProducer));
        }
    }
}
