namespace CleanArchitectureTemplate.Infrastructure.Extensions
{
    public static class CacheHelpers
    {
        public static string GenerateToDoItemsCacheKey()
        {
            return "todoitems";
        }
    }
}
