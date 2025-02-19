
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(2);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(90).MinimumLength(3);
            RuleFor(x => x.Cpf).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Telephone).NotEmpty().MaximumLength(50);
        }
    }
}
