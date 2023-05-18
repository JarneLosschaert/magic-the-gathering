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

            RuleFor(c => c.ManaCost).MaximumLength(255).WithMessage("ManaCost can't be longer than 255 characters");

            RuleFor(c => c.ConvertedManaCost).NotEmpty().WithMessage("ConvertedManaCost is required");
            RuleFor(c => c.ConvertedManaCost).MaximumLength(255).WithMessage("ConvertedManaCost can't be longer than 255 characters");

            RuleFor(c => c.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(c => c.Type).MaximumLength(255).WithMessage("Type can't be longer than 255 characters");

            RuleFor(c => c.RarityCode).MaximumLength(255).WithMessage("RarityCode can't be longer than 255 characters");

            RuleFor(c => c.SetCode).NotEmpty().WithMessage("SetCode is required");
            RuleFor(c => c.SetCode).MaximumLength(255).WithMessage("SetCode can't be longer than 255 characters");

            RuleFor(c => c.Number).NotEmpty().WithMessage("Number is required");
            RuleFor(c => c.Number).MaximumLength(255).WithMessage("Number can't be longer than 255 characters");

            RuleFor(c => c.Power).MaximumLength(255).WithMessage("Power can't be longer than 255 characters");

            RuleFor(c => c.Toughness).MaximumLength(255).WithMessage("Toughness can't be longer than 255 characters");

            RuleFor(c => c.Layout).NotEmpty().WithMessage("Layout is required");
            RuleFor(c => c.Layout).MaximumLength(255).WithMessage("Layout can't be longer than 255 characters");

            RuleFor(c => c.OriginalImageUrl).MaximumLength(255).WithMessage("OriginalImageUrl can't be longer than 255 characters");

            RuleFor(c => c.Image).NotEmpty().WithMessage("Image is required");
            RuleFor(c => c.Image).MaximumLength(255).WithMessage("Image can't be longer than 255 characters");

            RuleFor(c => c.OriginalType).MaximumLength(255).WithMessage("OriginalType can't be longer than 255 characters");

            RuleFor(c => c.MtgId).NotEmpty().WithMessage("MtgId is required");
            RuleFor(c => c.MtgId).MaximumLength(255).WithMessage("MtgId can't be longer than 255 characters");
        }
    }
}
