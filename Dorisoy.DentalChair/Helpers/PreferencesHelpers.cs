using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Dorisoy.DentalChair.Helpers;
public static class PreferencesHelpers
{
    public static T Get<T>(string key, T @default) where T : class
    {
        var result = @default;
        try
        {
            var serialized = Preferences.Get(key, string.Empty);
            if (string.IsNullOrEmpty(serialized))
            {
                return @default;
            }

            var serializeSettings = GetSerializerSettings();
            result = JsonConvert.DeserializeObject<T>(serialized);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error deserializing settings value: {ex}");
        }
        return result;
    }

    public static void Set<T>(string key, T obj) where T : class
    {
        try
        {
            var serializeSettings = GetSerializerSettings();
            var serialized = JsonConvert.SerializeObject(obj, serializeSettings);

            Preferences.Set(key, serialized);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error serializing settings value: {ex}");
        }
    }

    static JsonSerializerSettings GetSerializerSettings() => new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };
}
