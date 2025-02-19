using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Shared.Exceptions;
using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
  {


    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.Get(request.Id, cancellationToken) ?? throw new ExceptionErro("ID não existe");

      _mapper.Map(request, user); 
      _userRepository.Update(user); 

      await _unitOfWork.Commit(cancellationToken);

      return _mapper.Map<UpdateUserResponse>(user);
    }
  }
}
