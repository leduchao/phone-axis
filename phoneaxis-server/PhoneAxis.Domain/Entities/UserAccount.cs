using PhoneAxis.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneAxis.Domain.Entities;

public class UserAccount : BaseEntity
{
    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public bool IsRememberMe { get; set; }

    public LoginProvider LoginProvider { get; set; } = LoginProvider.None;

    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public MasterUser User { get; set; } = null!;
}
