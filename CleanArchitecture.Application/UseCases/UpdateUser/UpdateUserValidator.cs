using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
  {
    public UpdateUserValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
      RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
      RuleFor(x => x.Cpf).NotEmpty().MinimumLength(3);
      RuleFor(x => x.Email).NotEmpty().EmailAddress();
      RuleFor(x => x.Telephone).NotEmpty().MinimumLength(3);
    }
  }
}
