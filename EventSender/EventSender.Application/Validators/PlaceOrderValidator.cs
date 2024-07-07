using EventSender.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Application.Validators
{
    public sealed class PlaceOrderValidator : AbstractValidator<PlaceOrderRequest>
    {
        public PlaceOrderValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
        }
    }
}
