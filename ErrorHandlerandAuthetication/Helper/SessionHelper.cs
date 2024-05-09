using Newtonsoft.Json;

namespace ErrorHandlerandAuthetication.Helper
{
    public static class SessionHelper
    {
        public static void SetObjectTOSession<T>(this HttpContext httpContext,string key, T value)
        {
            if (IsSimpleType(typeof(T)))
                httpContext.Session.SetString(key, value.ToString());
            else
                httpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromSession<T>(this HttpContext httpContext, string key)
        {
            string? value =
                httpContext.Session.GetString(key);
            
            if(string.IsNullOrEmpty(value))
                return default(T);

            if (IsSimpleType(typeof(T)))
                return (T)Convert.ChangeType(value, typeof(T));
            else
                return JsonConvert.DeserializeObject<T>(value);
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsValueType || type == typeof(string);
        }
    }
}
