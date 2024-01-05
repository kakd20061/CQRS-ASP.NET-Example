using CQRS_Users.Models;
using MediatR;

namespace CQRS_Users.Queries;

public record GetUserByIdQuery(int id) : IRequest<UserModel>;
