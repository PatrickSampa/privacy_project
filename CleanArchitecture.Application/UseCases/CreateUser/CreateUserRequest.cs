
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(string Email, string Name ,string Password, string Cpf, string Telephone, bool AcountIsActive, string AboutMe) : IRequest<CreateUserResponse>
    {

    }
}
