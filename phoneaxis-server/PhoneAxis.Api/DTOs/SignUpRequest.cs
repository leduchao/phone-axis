using System.ComponentModel.DataAnnotations;

namespace PhoneAxis.Api.DTOs;

public record SignUpRequest(
    [Length(3, 100)] string? FirstName, 
    [Required][EmailAddress] string Email, 
    [Required][Length(6, 100)] string Password);
