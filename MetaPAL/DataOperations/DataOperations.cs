using MetaPAL.Data;
using MetaPAL.Models;
using MetaPAL.Resources;

namespace MetaPAL.DataOperations
{
    public static class DataOperations
    {
        public static async Task<Task> RemoveAll<T>(ApplicationDbContext context) where T : class
        {
            if (context.Set<T>() == null)
                throw new ArgumentException($"Entity set 'ApplicationDbContext.{typeof(T).Name}'  is null.");

            context.Set<T>().RemoveRange(context.Set<T>());
            await context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public static async Task<bool> AddMetaDataFromSdrf(ApplicationDbContext context, string sdrfPath)
        {
            if (context.MetaData == null)
                throw new ArgumentException($"Entity set 'ApplicationDbContext.MetaData'  is null.");

            var sdrfFile = new SdrfFile(sdrfPath);
            // the fields are excluded because they are not useful for searching and are components of other parts of the database
            foreach (var result in sdrfFile.Results.Where(p => p.Name is not ("data file" or "file uri" or "source name" or "assay name")))
            {
                var existing = context.MetaData.FirstOrDefault(p => p.Name == result.Name && p.Value == result.Value);
                if (existing == null)
                    context.MetaData.Add(result);
            }

            await context.SaveChangesAsync();

            return true;
        }
    }
}
