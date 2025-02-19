using CleanArchitecture.Application.Shared.Exceptions;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Application.UseCases.GetUser;
using CleanArchitecture.Application.UseCases.UpdateUser;
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


    [HttpGet("GetAll")]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
      var response = await _Mediator.Send(new GetAllUserRequest(), cancellationToken);
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
      catch (ExceptionErro err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetById(Guid id, CancellationToken cancellationToken)
    {
      try
      {
        var response = await _Mediator.Send(new GetUserRequest(id), cancellationToken);
        return Ok(response);
      }
      catch (ExceptionErro err)
      {
        return BadRequest(err.Message);
      }

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<string>> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
      try
      {
        if (id != request.Id)
        {
          return BadRequest("O ID do usuário não corresponde ao ID fornecido.");
        }
        
        var response = await _Mediator.Send(request, cancellationToken);
        return Ok(response);
      }
      catch (ExceptionErro err)
      {
        return BadRequest(err.Message);
      }
    }


  }
}
