using Core.Entities.Concrete;
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
            RuleFor(c => c.RegistryName).Must(name => name != null && name.ToLower().StartsWith("ab"))
                .WithMessage("Sicil ab başlamalıdır.");
        }
    }
}
