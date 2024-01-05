using CQRS_Users.Commands;
using CQRS_Users.Models;
using CQRS_Users.Models.DTOs;
using CQRS_Users.Queries;
using CQRS_Users.Repositories;
using MediatR;

namespace CQRS_Users.Handlers.Commands;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
{

    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserModel(default, request.model.email, request.model.password);
        return await _userRepository.CreateUser(user);
    }
}

