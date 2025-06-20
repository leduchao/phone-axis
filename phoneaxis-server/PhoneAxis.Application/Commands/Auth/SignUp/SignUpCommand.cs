using MediatR;
using PhoneAxis.Application.DTOs.Auth;

namespace PhoneAxis.Application.Commands.Auth.SignUp;

public record SignUpCommand(string? FirstName, string Email, string Password) : IRequest<AuthResponse>;
