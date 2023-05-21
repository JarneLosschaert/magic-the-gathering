using FluentValidation;
using Howest.MagicCards.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.Shared.Validation
{
    public class CardDeckCustomValidator : AbstractValidator<CardDeck>
    {
        public CardDeckCustomValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().WithMessage("Id is required");

            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(c => c.Name).MaximumLength(255).WithMessage("Name can't be longer than 255 characters");

            RuleFor(c => c.Amount).NotEmpty().WithMessage("Amount is required");
        }
    }
}
