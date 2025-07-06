namespace PhoneAxis.Domain.Entities;

public class Category(string categoryName, string? description) : BaseEntity
{
	public string CategoryName { get; set; } = categoryName;

	public string? Description { get; set; } = description;

	public IList<Product> Products { get; set; } = [];
}
