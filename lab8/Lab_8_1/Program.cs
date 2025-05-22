using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class VectorProcessor
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "vectors.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        string content = File.ReadAllText(inputFile);

        string vectorPattern = @"(\(\s*-?\d+(\.\d+)?\s*,\s*-?\d+(\.\d+)?\s*\))|(\[\s*-?\d+(\.\d+)?\s*;\s*-?\d+(\.\d+)?\s*\])";
        MatchCollection matches = Regex.Matches(content, vectorPattern);

        List<string> vectors = new List<string>();
        foreach (Match m in matches)
        {
            vectors.Add(m.Value);
        }

        Console.WriteLine($"Vectors found: {vectors.Count}");
        foreach (var v in vectors)
        {
            Console.WriteLine(v);
        }

        try
        {
            File.WriteAllLines(outputFile, vectors);
            Console.WriteLine($"\nVectors saved to file: {outputFile}");
            Console.WriteLine("Vectors saved to file: " + Path.GetFullPath(outputFile));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing file: {ex.Message}");
            return;
        }

        Console.WriteLine("\nDo you want to replace a specific vector? (yes/no)");
        string answer = Console.ReadLine()?.Trim().ToLower();

        if (answer == "yes")
        {
            Console.Write("Enter the vector to replace: ");
            string target = Console.ReadLine();
            Console.Write("Enter the replacement value: ");
            string replacement = Console.ReadLine();

            if (!string.IsNullOrEmpty(target))
            {
                string updatedContent = Regex.Replace(content, Regex.Escape(target), replacement);

                string modifiedFile = "modified_text.txt";
                File.WriteAllText(modifiedFile, updatedContent);
                Console.WriteLine($"Modified text saved to: {modifiedFile}");
            }
            else
            {
                Console.WriteLine("Invalid input for vector to replace.");
            }
        }
        else
        {
            Console.WriteLine("No replacements done.");
        }
    }
}
