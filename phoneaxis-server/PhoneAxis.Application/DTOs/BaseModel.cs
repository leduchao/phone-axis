namespace PhoneAxis.Application.DTOs;

public class BaseModel
{
    public Guid Id { get; set; }

    public BaseModel()
    {
        
    }

    public BaseModel(Guid id)
    {
        Id = id;
    }
}
