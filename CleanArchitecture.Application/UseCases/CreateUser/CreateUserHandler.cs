using AutoMapper;
using CleanArchitecture.Application.Shared.Exceptions;
using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
  public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
  {


    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _userRepository = userRepository;
      _mapper = mapper;
    }



    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
      var user = _mapper.Map<User>(request);


      var userEmailExist = await _userRepository.GetByEmail(user.Email, cancellationToken);

      var userCpfExist = await _userRepository.GetByCpf(user.Cpf, cancellationToken);

      if (userEmailExist != null) throw new ExceptionErro("Email ja cadastrado");

      if (userCpfExist != null) throw new ExceptionErro("Cpf ja Cadastrado");



      _userRepository.Create(user);

      await _unitOfWork.Commit(cancellationToken);

      return _mapper.Map<CreateUserResponse>(user);
    }
  }
}
