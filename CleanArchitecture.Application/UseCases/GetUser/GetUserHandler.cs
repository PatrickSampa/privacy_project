
using AutoMapper;
using CleanArchitecture.Application.Shared.Exceptions;
using CleanArchitectureDomain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser
{
  public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.Get(request.guid, cancellationToken);

      return  user == null ? throw new ExceptionErro("ID não existe") : _mapper.Map<GetUserResponse>(user);
    }
  }
}
