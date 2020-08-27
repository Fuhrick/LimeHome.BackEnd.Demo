using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimeHome.BackEnd.Demo.Helpers
{
    // Summary:
    //     Defines the methods that are required for a value provider.
    public interface IValueProvider
    {
        //
        // Summary:
        //     Determines whether the collection contains the specified prefix.
        //
        // Parameters:
        //   prefix:
        //     The prefix to search for.
        //
        // Returns:
        //     true if the collection contains the specified prefix; otherwise, false.
        bool ContainsPrefix(string prefix);
        //
        // Summary:
        //     Retrieves a value object using the specified key.
        //
        // Parameters:
        //   key:
        //     The key of the value object to retrieve.
        //
        // Returns:
        //     The value object for the specified key. If the exact key is not found, null.
        ValueProviderResult GetValue(string key);
    }
}
