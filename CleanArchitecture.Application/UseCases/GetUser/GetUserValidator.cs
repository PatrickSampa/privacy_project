
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetUser
{
    public class GetUserValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserValidator()
        {
            RuleFor(x => x.guid).NotEmpty().WithMessage("O GUID não pode estar vazio.");
        }
    }
}
