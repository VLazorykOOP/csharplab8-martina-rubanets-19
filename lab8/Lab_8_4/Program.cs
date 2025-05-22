using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string sentence = "Дана пропозиція. Створити файл і записати в нього всі символи даного пропозиції, відмінні від розділових знаків.";

        char[] punctuation = new char[] { '.', ',', '!', '?', ':', ';', '-', '—', '(', ')', '"', '\'' };

        StringBuilder filtered = new StringBuilder();

        foreach (char c in sentence)
        {
            if (Array.IndexOf(punctuation, c) == -1)
            {
                filtered.Append(c);
            }
        }

        string filteredSentence = filtered.ToString();

        string fileName = "sentence.bin";

        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
        {
            writer.Write(filteredSentence);
        }

        string fullPath = Path.GetFullPath(fileName);
        Console.WriteLine($"Файл записаний за шляхом: {fullPath}");

        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
        {
            string content = reader.ReadString();
            Console.WriteLine("Вміст файлу:");
            Console.WriteLine(content);
        }
    }
}
