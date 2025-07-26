using Microsoft.AspNetCore.Mvc.ModelBinding;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Api.Utils;

public static class PresentationUtils
{
    public static IEnumerable<Error> GetModelStateErrors(ModelStateDictionary modelState)
    {
        return modelState.SelectMany(p => (p.Value?.Errors ?? []).Select(e => new Error(p.Key, e.ErrorMessage)));
    }
}
