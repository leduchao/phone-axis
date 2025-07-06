using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Entities;

public class Order : BaseEntity
{
    public string? OrderCode { get; set; }

    public decimal TotalAmount { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.None;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public IList<OrderDetail> OrderDetails { get; set; } = [];
}
