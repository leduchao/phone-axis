using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Commands.Auth.SignIn;

public record SignInCommand(string Email, string Password, bool RememberMe) : IRequest<Result<SignInResponse>>;
