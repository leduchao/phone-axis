using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Entities;

public class Phone : Product
{
    public PhoneType Type { get; set; } = PhoneType.None;

    public Phone(string productName, decimal price) : base(productName, price)
    {
        ProductType = ProductType.Phone;
    }
}
