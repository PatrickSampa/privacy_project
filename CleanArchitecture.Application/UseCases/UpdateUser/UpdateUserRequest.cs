
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserRequest : IRequest<UpdateUserResponse>
  {
    public Guid Id { get; init; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Cpf { get; set; }
    public string? Telephone { get; set; }
    public bool? AcountIsActive { get; set; }
    public string? AboutMe { get; set; }
  }
}
