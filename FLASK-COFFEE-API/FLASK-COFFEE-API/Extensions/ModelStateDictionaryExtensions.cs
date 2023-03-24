using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FLASK_COFFEE_API.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static Dictionary<string, string[]> GenerateCustomErrorModel(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray());

        }
    }
}
