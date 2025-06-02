using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class CourthouseDtoValidator: AbstractValidator<CourthouseDto>
    {
        public CourthouseDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(5);
            RuleFor(c => c.CityId).NotEmpty();
            RuleFor(c => c.Name).Must(name => name != null && name.ToLower().EndsWith(" adliyesi"))
                .WithMessage("Adliyesi ile biten bir isim olmalıdır.");
        }
    }
}
