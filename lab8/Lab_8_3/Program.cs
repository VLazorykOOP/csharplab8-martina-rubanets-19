using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Вхідний файл '{inputFile}' не знайдено.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);

        if (lines.Length < 3)
        {
            Console.WriteLine("У вхідному файлі недостатньо рядків (потрібно 3).");
            return;
        }

        string firstText = lines[0];
        string secondText = lines[1];
        string word = lines[2];

        string result = InsertTextAfterWord(firstText, secondText, word);

        File.WriteAllText(outputFile, result);

        string fullPath = Path.GetFullPath(outputFile);
        Console.WriteLine($"Результат записано у файл:\n{fullPath}");
    }

    static string InsertTextAfterWord(string firstText, string secondText, string word)
    {
        string pattern = $@"\b{Regex.Escape(word)}\b";

        string replaced = Regex.Replace(firstText, pattern, match => match.Value + " " + secondText, RegexOptions.IgnoreCase);

        return replaced;
    }
}
