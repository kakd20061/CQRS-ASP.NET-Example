using CQRS_Users.Models;
using CQRS_Users.Models.DTOs;
using MediatR;

namespace CQRS_Users.Commands;

public record UpdateUserCommand(UserModel model) : IRequest<bool>;