using MediatR;
using PhoneAxis.Application.DTOs.Auth;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Queries.Auth;

public record SignInQuery(
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password, 
    bool RememberMe) : IRequest<Result<SignInResponse>>;
