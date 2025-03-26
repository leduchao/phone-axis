namespace PhoneAxis.Domain.Entities;

public class MasterUser : BaseEntity
{
    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ContactEmail { get; set; } = string.Empty;

    public UserAccount UserAccount { get; set; } = null!;
}
