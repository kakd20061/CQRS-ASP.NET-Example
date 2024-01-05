using MediatR;

namespace CQRS_Users.Commands;

public record DeleteUserCommand(int id) : IRequest<bool>;
