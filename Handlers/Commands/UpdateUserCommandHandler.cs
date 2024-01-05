using CQRS_Users.Commands;
using CQRS_Users.Models;
using CQRS_Users.Repositories;
using MediatR;

namespace CQRS_Users.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.model.id);
        if (user is null) return false;

        return await _userRepository.UpdateUser(user,request.model);
    }
}
