namespace PhoneAxis.Domain.Entities;

public class ProductImage : BaseEntity
{
    public string Url { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;
}
