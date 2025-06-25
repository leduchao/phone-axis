using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PhoneAxis.Api.Utils;

public static class PresentationUtils
{
    public static IEnumerable<string> GetModelStateErrors(ModelStateDictionary modelState)
    {
        return modelState.Values.SelectMany(p => p.Errors).Select(p => p.ErrorMessage);
    }
}
