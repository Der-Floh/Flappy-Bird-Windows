using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Flappy_Bird_Windows.Utility;

public static class CSVSerializer
{
    public static IEnumerable<T> Deserialize<T>(string csvString) where T : new()
    {
        var result = new List<T>();

        using var reader = new StringReader(csvString);
        using var parser = new TextFieldParser(reader);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var propertyNames = new List<string>();

        var isFirstRow = true;
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            if (fields is null)
                continue;

            if (isFirstRow)
            {
                propertyNames.AddRange(fields);
                isFirstRow = false;
                continue;
            }

            var obj = new T();
            for (int i = 0; i < fields.Length && i < propertyNames.Count; i++)
            {
                var propertyName = propertyNames[i];
                var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (property == null)
                    continue;

                var value = StringToValue(property.PropertyType, fields[i]);
                property.SetValue(obj, value);
            }

            result.Add(obj);
        }

        return result;
    }

    public static string Serialize<T>(IEnumerable<T> items)
    {
        var sb = new StringBuilder();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        foreach (var item in items)
        {
            var values = properties.Select(p => ValueToString(p.GetValue(item, null)));
            sb.AppendLine(string.Join(",", values));
        }

        return sb.ToString();
    }

    private static object? StringToValue(Type propertyType, string value)
    {
        if (string.IsNullOrEmpty(value))
            return propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;

        var underlyingType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

        if (underlyingType.IsEnum)
            return Enum.Parse(underlyingType, value, true);

        try
        {
            return Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture);
        }
        catch (InvalidCastException)
        {
            throw new NotSupportedException($"Type {propertyType} is not supported.");
        }
    }

    private static string ValueToString(object? value)
    {
        if (value is null)
            return string.Empty;

        if (value is string stringValue)
            return EscapeCsvValue(stringValue);

        if (value is bool boolValue)
            return boolValue.ToString().ToLowerInvariant();

        return EscapeCsvValue(Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty);
    }

    private static string EscapeCsvValue(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            return $"\"{value.Replace("\"", "\"\"")}\"";
        return value;
    }
}
