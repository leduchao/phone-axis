using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Cryptography;

namespace PhoneAxis.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public MasterUser User { get; set; } = null!;

    public ICollection<CartItem> Items { get; set; } = [];

    public decimal TotalAmount => Items.Sum(i => i.SubTotal);

    public Cart() { }

    public Cart(Guid? userId)
    {
        UserId = userId;
    }

    public void AddItem(Guid productId, int quantity, decimal unitPrice)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            Items.Add(new CartItem(productId, quantity, unitPrice));
        }
    }

    public void UpdateItemQuantity(Guid productId, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        item?.SetQuantity(quantity);
    }

    public void RemoveItem(Guid productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item is not null) Items.Remove(item);
    }

    public void ClearCart()
    {
        Items.Clear();
    }
}
