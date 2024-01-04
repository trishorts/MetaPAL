using System.Text.RegularExpressions;

namespace MetaPAL.Resources.MetaData.SDRF
{
    public static class SdrfToMetaData
    {
        private static string _withinBraces = @"\[(.*?)\]";
        public static Dictionary<string, List<string>> ParseMetaDataFile(string sdrfPath)
        {
            List<(string, List<string>)> headerToValues = new List<(string, List<string>)>();

            // parse header and add all columns to dictionary then find distinct values
            using (var streamReader = new StreamReader(File.OpenRead(sdrfPath)))
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

        public static IEnumerable<Models.MetaData> GetMetaData(string sdrfPath)
        {
            foreach (var (header, values) in ParseMetaDataFile(sdrfPath))
                foreach (var value in values)
                    yield return new Models.MetaData() { Name = header, Value = value };
        }
    }
}
