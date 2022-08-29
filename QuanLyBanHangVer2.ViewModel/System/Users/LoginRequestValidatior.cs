using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class LoginRequestValidatior : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidatior()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User Name is required")
                .Length(3,20).WithMessage("User Name must between 3 and 20 characters");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(3, 20).WithMessage("User Name at least 6 characters");
        }
    }
}