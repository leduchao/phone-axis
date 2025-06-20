using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Api.DTOs;

public record SignInRequest(
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password,
    bool RememberMe);
