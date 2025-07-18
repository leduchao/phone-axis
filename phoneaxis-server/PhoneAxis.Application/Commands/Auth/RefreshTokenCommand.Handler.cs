using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Application.Interfaces.Services;

namespace PhoneAxis.Application.Commands.Auth;

public class RefreshTokenCommandHandler(IUserService userService, IJwtService jwtService) : IRequestHandler<RefreshTokenCommand, TokenModel?>
{
    private readonly IUserService _userService = userService;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<TokenModel?> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var (isValidToken, userId, email) = await _userService.ValidateRefreshTokenAsync(request.RefreshToken);
        if (!isValidToken) return null;

        var newRefreshToken = _jwtService.GenerateRefreshToken();
        await _userService.UpdateRefreshTokenAsync(userId.ToString()!, newRefreshToken);

        return new TokenModel(_jwtService.GenerateAccessToken(userId.GetValueOrDefault(), email!), newRefreshToken);
    }
}
