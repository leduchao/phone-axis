using MediatR;
using PhoneAxis.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Application.Commands.Auth;

public record SignUpCommand(
    [Length(3, 100)] string? FirstName, 
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password) : IRequest<Result>;
