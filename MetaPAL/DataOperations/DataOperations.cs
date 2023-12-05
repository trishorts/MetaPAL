using MetaPAL.Data;

namespace MetaPAL.DataOperations
{
    public static class DataOperations
    {
        public static async void RemoveAll<T>(ApplicationDbContext context) where T : class
        {
            if (context.Set<T>() == null)
                throw new ArgumentException($"Entity set 'ApplicationDbContext.{typeof(T).Name}'  is null.");

            context.Set<T>().RemoveRange(context.Set<T>());
            await context.SaveChangesAsync();
        }
    }
}
