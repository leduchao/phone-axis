namespace PhoneAxis.Domain.Entities;

public class Category : BaseEntity
{
    public required string CategoryName { get; set; }

    public string? Description { get; set; }

    public List<Product> Products { get; set; } = [];
}
