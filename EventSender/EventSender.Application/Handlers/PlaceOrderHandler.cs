using AutoMapper;
using EventSender.Application.Commands;
using EventSender.Application.Contract.IInfrastructure;
using EventSender.Application.Dtos;
using EventSender.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Application.Handlers
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderRequest, GetOrderDto>
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IMapper _mapper;
        public PlaceOrderHandler(IMessageProducer messageProducer, IMapper mapper)
        {
            _messageProducer = messageProducer;
            _mapper = mapper;
        }

        public async Task<GetOrderDto> Handle(PlaceOrderRequest request, CancellationToken cancellationToken) 
        {
            var order = _mapper.Map<Order>(request);

            _messageProducer.SendMessage(order);

            return _mapper.Map<GetOrderDto>(order);
        }
    }
}
