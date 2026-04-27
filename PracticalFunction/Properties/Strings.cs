namespace PracticalFunction.Properties
{
    internal partial class Strings
    {
        public static string Get(string key)
        {
            return ResourceManager.GetString(key, resourceCulture) ?? key;
        }
    }
}
