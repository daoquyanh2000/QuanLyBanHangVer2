using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class CreateRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().Length(1, 20)
                .WithMessage("First Name must have 1 to 20 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().Length(1, 20)
                .WithMessage("Last Name must have 1 to 20 characters");

            RuleFor(x => x.UserName)
            .NotEmpty().Length(6, 20)
            .WithMessage("User Name must have 6 to 20 characters");

            RuleFor(x => x.Password)
            .NotEmpty().Length(6, 20)
            .WithMessage("Password must have 6 to 20 characters");

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.ConfirmPassword != request.Password)
                {
                    context.AddFailure("Confirm password is not match!");
                }
            });
        }
    }
}