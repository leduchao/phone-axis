using MediatR;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Commands.Auth.SignUp;

public record SignUpCommand(string? FirstName, string Email, string Password) : IRequest<Result>;
