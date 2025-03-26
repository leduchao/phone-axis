namespace PhoneAxis.Domain.Enums;

public enum ProductType
{
    None,
    Phone,
    Headphone,
    Speaker,
    Charger
}

public enum PhoneType
{
    None,
    TouchScreen, // smart phone
    Keyboard,
    Hybrid
}

public enum OrderStatus
{
    None,
    Pending,
    Confirmed,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
}

public enum LoginProvider
{
    None,
    Google,
    Facebook,
    Microsoft,
    X,
    TikTok
}
