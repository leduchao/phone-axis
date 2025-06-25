namespace PhoneAxis.Domain.Entities;

public class MasterUser : BaseEntity
{
    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) ? $"{FirstName} {LastName}" : FirstName;

    public string? ContactEmail { get; set; } = string.Empty;

    public MasterUser()
    {

    }

    public MasterUser(Guid id, string userName, string firstName, string contactEmail)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        ContactEmail = contactEmail;
    }
}
