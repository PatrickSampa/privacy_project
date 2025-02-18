using CleanArchitecture.Application.Shared.Exceptions;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly IMediator _Mediator;

    public UserController(IMediator mediator)
    {
      _Mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
      var response = await _Mediator.Send(new GetAllUserResponse(), cancellationToken);
      return Ok(response);
    }


    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken canceletionToken)
    {
            try
            {
                var response = await _Mediator.Send(request, canceletionToken);
                return Ok(response);
            }
            catch (ExceptionErro err) {
                return BadRequest(err.Message);
            }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> GetById(string id, CancellationToken cancellationToken)
    {
      if (int.TryParse(id, out _))
      {
        throw new ExceptionErro("valor errado", 400);
        return Ok(id);
      }
      return Ok("teste");
    }

  }
}
