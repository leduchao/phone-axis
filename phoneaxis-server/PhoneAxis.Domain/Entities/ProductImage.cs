namespace PhoneAxis.Domain.Entities;

public class ProductImage : BaseEntity
{
    public required string Url { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;
}
