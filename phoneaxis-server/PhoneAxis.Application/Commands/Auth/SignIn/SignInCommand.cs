using MediatR;
using PhoneAxis.Application.DTOs.Auth;

namespace PhoneAxis.Application.Commands.Auth.SignIn;

public record SignInCommand(string Email, string Password, bool RememberMe) : IRequest<AuthResponse>;
