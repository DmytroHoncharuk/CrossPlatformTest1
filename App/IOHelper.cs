using System.Globalization;

namespace App;

public static class IOHelper
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static int ReadSingleNumberFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new FileNotFoundException($"�� ������� ������ ����: {InputFileName}.");
        }

        var lines = File.ReadAllLines(InputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new FormatException("���� �� ���� ���� �������.");
        }

        if (lines.Length != 1)
        {
            throw new FormatException("���� ������� ������ ���� ���� ����� �� ������.");
        }

        if (!int.TryParse(lines[0], out var numberofLevels))
        {
            throw new FormatException("��� � ���� ������ ������ ���� ���� �����.");
        }

        return numberofLevels;
    }

    public static void WriteResultToFile(int result)
    {
        File.WriteAllText(OutputFileName, result.ToString(CultureInfo.InvariantCulture));
    }
}
