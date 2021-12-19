using AnindaKapinda.DAL;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API
{
    public class UserValidator : AbstractValidator<UserModelForRegister>

    {
        public UserValidator()
        {
            RuleFor(a=>a.Password)
                      .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage("Şifre en az 8 karakter olmalı ve büyük harf, küçük harf ve rakam içermelidir");



        }
    }
}
