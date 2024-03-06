using System.Text.RegularExpressions;
using Readers;

namespace MetaPAL.Resources
{
    /// <summary>
    /// IMPORTANT: This class returns unique MetaData pairs, but does not preserve order
    /// </summary>
    public class SdrfFile : ResultFile<Models.SampleMetaData>
    {
        private static string _withinBraces = @"\[(.*?)\]";
        public SdrfFile(string path) : base(path, Software.Unspecified)
        {
            //FileType = SupportedFileType.Sdrf;
        }

        public override void LoadResults()
        {
            var results = new List<Models.SampleMetaData>();
            foreach (var (header, values) in ParseDelimitedFile(FilePath))
                foreach (var value in values)
                    results.Add(new Models.SampleMetaData() { Name = header, Value = value });
            Results = results;
        }

        public override void WriteResults(string outputPath)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, List<string>> ParseDelimitedFile(string filePath)
        {
            List<(string, List<string>)> headerToValues = new List<(string, List<string>)>();

            // parse header and add all columns to dictionary then find distinct values
            using (var streamReader = new StreamReader(File.OpenRead(filePath)))
            {
                var header = streamReader.ReadLine();
                var headerColumns = header.Split('\t');
                foreach (var headerColumn in headerColumns)
                {
                    if (headerColumn.Contains("[") && headerColumn.Contains("]"))
                    {
                        var match = Regex.Match(headerColumn, _withinBraces);
                        if (match.Success)
                            headerToValues.Add((match.Groups[1].Value, new List<string>()));
                    }
                    else
                        headerToValues.Add((headerColumn, new List<string>()));
                }

                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split('\t');
                    for (int i = 0; i < values.Length; i++)
                    {
                        headerToValues[i].Item2.Add(values[i]);
                    }
                }
            }
            // collapse repeated headers and remove duplicates from values
            return headerToValues.GroupBy(x => x.Item1)
                .ToDictionary(x => x.Key,
                    x => x.SelectMany(y => y.Item2)
                        .Distinct()
                        .ToList());
        }

        public override SupportedFileType FileType { get; }
        public override Software Software { get; set; }
    }
}
