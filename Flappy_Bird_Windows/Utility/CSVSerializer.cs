using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

namespace Flappy_Bird_Windows.Utility;

public static class CSVSerializer
{
    public static IEnumerable<T> Deserialize<T>(string csvString) where T : new()
    {
        using var reader = new StringReader(csvString);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            PrepareHeaderForMatch = args => args.Header.Trim(),
            MissingFieldFound = null,
            HeaderValidated = null,
        };

        using var csv = new CsvReader(reader, config);

        return [.. csv.GetRecords<T>()];
    }

    public static string Serialize<T>(IEnumerable<T> items)
    {
        using var writer = new StringWriter();

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using var csv = new CsvWriter(writer, config);

        csv.WriteRecords(items);

        return writer.ToString();
    }
}
