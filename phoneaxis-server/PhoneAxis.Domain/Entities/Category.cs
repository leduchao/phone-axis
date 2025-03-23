namespace PhoneAxis.Domain.Entities;

public class Category : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public List<Phone> Phones { get; set; } = [];
}
