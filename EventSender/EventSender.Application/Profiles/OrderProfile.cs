using AutoMapper;
using EventSender.Application.Commands;
using EventSender.Application.Dtos;
using EventSender.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Application.Profiles
{
    public sealed class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<PlaceOrderRequest, Order>();
            CreateMap<Order, GetOrderDto>();
        }
    }
}
