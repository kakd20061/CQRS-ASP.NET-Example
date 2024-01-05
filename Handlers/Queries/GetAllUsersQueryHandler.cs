using CQRS_Users.Models;
using CQRS_Users.Queries;
using CQRS_Users.Repositories;
using MediatR;

namespace CQRS_Users.Handlers.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUsers();
    }
}
