﻿using DevLibrary.Application.Commands.CreateLoan;
using FluentValidation;

namespace DevLibrary.Application.Validators
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(l => l.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("IdUser is a mandatory field.");

            RuleFor(l => l.IdBook)
              .NotEmpty()
              .NotNull()
              .WithMessage("IdBook is a mandatory field.");

            RuleFor(l => l.LoanedQuantity)
              .NotEmpty()
              .NotNull()
              .WithMessage("LoanedQuantity is a mandatory field.");

            RuleFor(l => l.NumberLoanDay)
              .NotEmpty()
              .NotNull()
              .WithMessage("NumberLoanDay is a mandatory field.");
        }
    }
}
