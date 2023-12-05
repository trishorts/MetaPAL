using MetaPAL.Data;
using MetaPAL.Models;
using Readers;

namespace MetaPAL.DataOperations
{
    public static class BulkUploader
    {
        /// <summary>
        /// Adds psms from file to the database.
        /// CAREFUL: must ensure that context.SpectrumMatch is not null prior to calling this method to avoid null reference exception.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="psmPath"></param>
        /// <exception cref="ArgumentException"></exception>
        public static async void AddPsmsToDb(ApplicationDbContext context, string psmPath)
        {
            if (psmPath.ParseFileType() != SupportedFileType.psmtsv)
                throw new ArgumentException("File type is not supported.");

            var psms = SpectrumMatchTsvReader.ReadTsv(psmPath, out _);

            int oldMaxId = context.SpectrumMatch!.Any() ? context.SpectrumMatch!.Max(x => x.Id) + 1 : 0;
            for (int nextId = oldMaxId; nextId < psms.Count + oldMaxId; nextId++)
            {
                var match = SpectrumMatch.FromSpectrumMatchTsv(psms[nextId - oldMaxId]);
                context.Add(match);
            }

            await context.SaveChangesAsync();
        }
    }
}
