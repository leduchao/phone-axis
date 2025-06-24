namespace PhoneAxis.Application.Interfaces.Services;

public interface ITokenClaimReader
{
    Guid? GetUserId();
}
