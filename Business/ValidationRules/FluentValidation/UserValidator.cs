﻿using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.RegistryName).NotEmpty();
            RuleFor(u => u.RegistryName).MinimumLength(5);
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(c => c.RegistryName).Must(name => name != null && name.ToLower().StartsWith("ab"))
                .WithMessage("Sicil ab ile başlamalıdır.");
        }
    }
}
