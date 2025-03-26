using System.ComponentModel.DataAnnotations.Schema;
using PhoneAxis.Domain.Enums;

namespace PhoneAxis.Domain.Entities;

public class Phone : Product
{
    public PhoneType Type { get; set; } = PhoneType.None;

    public Phone()
    {
        ProductType = ProductType.Phone;
    }
}
