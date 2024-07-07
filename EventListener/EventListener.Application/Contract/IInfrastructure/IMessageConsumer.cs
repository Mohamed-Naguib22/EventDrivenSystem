using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Application.Contract.IInfrastructure
{
    public interface IMessageConsumer
    {
        void RecieveMessage();
    }
}
