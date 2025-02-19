

namespace CleanArchitecture.Application.UseCases.GetUser
{
  public sealed class GetUserResponse()
  {
    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
  }
}
