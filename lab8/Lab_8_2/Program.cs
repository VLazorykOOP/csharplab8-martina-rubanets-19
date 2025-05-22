using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";    
        string outputFile = "output.txt";  

        string text = File.ReadAllText(inputFile);

        string pattern = @"\b[_a-zA-Z][_a-zA-Z0-9]*\b";

        string result = Regex.Replace(text, pattern, "");

        File.WriteAllText(outputFile, result);

        Console.WriteLine($"Обробка завершена. Результат записано у файл: {Path.GetFullPath(outputFile)}");
    }
}
