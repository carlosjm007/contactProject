using FluentValidation;
using FluentValidation.Validators;
using ContactProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Validators
{
    public class ContactValidator : AbstractValidator<ContactModel>
    {
        private string emailRegex = @"^\w+([-+.']\w+)*([-+.'])*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public ContactValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode("email_required")
                .WithMessage("Email is required");

            RuleFor(x => x.Email)
                .Matches(emailRegex)
                .WithErrorCode("email_invalid")
                .WithMessage("A valid email is required");

            When(x => (x.PhoneNumberPersonal == null && x.PhoneNumberWork == null), () =>
            {
                RuleFor(x => x.PhoneNumberWork)
                    .NotEmpty()
                    .WithErrorCode("at_least_a_phone_required")
                    .WithMessage("At least one phone is required (work or personal)");
            });
        }
    }
}
