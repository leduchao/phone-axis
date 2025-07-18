using MediatR;
using PhoneAxis.Application.DTOs.Auth;

namespace PhoneAxis.Application.Commands.Auth;

public record RefreshTokenCommand(string RefreshToken) : IRequest<TokenModel?>;
