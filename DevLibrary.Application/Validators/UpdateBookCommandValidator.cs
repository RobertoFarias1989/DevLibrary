using DevLibrary.Application.Commands.DeleteBook;
using DevLibrary.Application.Commands.UpdateBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
              .MaximumLength(254)
              .WithMessage("Title's maximum length is around 254 character.");

            RuleFor(b => b.Author)
                .MaximumLength(100)
                .WithMessage("Author's maximum length is around 100 character.");

            RuleFor(b => b.ISBN)
                .MaximumLength(13)
                .WithMessage("ISBN's maximum length is around 13 character.");
        }
    }
}
