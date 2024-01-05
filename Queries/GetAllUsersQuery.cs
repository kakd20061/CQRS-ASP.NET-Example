using CQRS_Users.Models;
using MediatR;

namespace CQRS_Users.Queries;

public record GetAllUsersQuery() : IRequest<List<UserModel>>;
