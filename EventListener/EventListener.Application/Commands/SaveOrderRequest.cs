using EventListener.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Application.Commands
{
    public sealed record SaveOrderRequest(Order Order) : IRequest;
}
