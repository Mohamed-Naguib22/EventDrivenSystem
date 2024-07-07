using EventListener.Application.Commands;
using EventListener.Application.Contract.IRepositories.ICommon;
using EventListener.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Application.Handlers
{
    public class SaveOrderHandler : IRequestHandler<SaveOrderRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaveOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SaveOrderRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetRepository<Order>().AddAsync(request.Order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
