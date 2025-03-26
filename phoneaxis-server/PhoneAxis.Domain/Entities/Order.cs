using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Entities;

public class Order : BaseEntity
{
    public string? OrderCode { get; set; }

    public required decimal TotalAmount { get; set; }

    public required string CustomerName { get; set; }

    public required string CustomerPhone { get; set; }

    public required string ShippingAddress { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.None;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
}
