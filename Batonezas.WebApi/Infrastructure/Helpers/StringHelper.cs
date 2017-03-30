namespace Batonezas.WebApi.Infrastructure.Helpers
{
    public static class StringHelper
    {
        public static bool Contains(string original, string filter)
        {
            original = original.ToLower();
            filter = filter.ToLower();

            return original.Contains(filter);
        }
    }
}