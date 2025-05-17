using System.Text.Json;

namespace ASPMotoDrive.Data.Models.Cookies
{
    public static class CookieHelper
    {
        public static void SetObject(HttpResponse response, string key, object value, int? expireDays = null)
        {
            var options = new CookieOptions();
            if (expireDays.HasValue)
                options.Expires = DateTime.Now.AddDays(expireDays.Value);

            var json = JsonSerializer.Serialize(value);
            response.Cookies.Append(key, json, options);
        }

        public static T GetObject<T>(HttpRequest request, string key)
        {
            request.Cookies.TryGetValue(key, out var json);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
    }
}
