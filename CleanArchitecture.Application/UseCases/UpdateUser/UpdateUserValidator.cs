
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
  {
    public UpdateUserValidator()
    {
      RuleFor(x => x.Id).NotEmpty();
      RuleFor(x => x.Name).MinimumLength(3);
      RuleFor(x => x.Cpf).MinimumLength(3);
      RuleFor(x => x.Email).EmailAddress();
      RuleFor(x => x.Telephone).MinimumLength(3);
      RuleFor(x => x.AboutMe).MaximumLength(1000);
      RuleFor(x => x.AcountIsActive)
    .Must(x => x == null || x.GetType() == typeof(bool))
    .WithMessage("AcountIsActive deve ser um valor booleano.");
    }
  }
}
