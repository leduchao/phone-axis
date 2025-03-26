using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneAxis.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; } = default;

    public decimal UnitPrice { get; set; }
}
