using CQRS_Users.Models.DTOs;
using MediatR;

namespace CQRS_Users.Commands;

public record AddUserCommand(UserDto model) : IRequest<bool>;
