using EventSender.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Application.Commands
{
    public sealed record PlaceOrderRequest(decimal Price) : IRequest<GetOrderDto>;
}
